namespace EducationalMaterials.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _hasher;
        private readonly IConfiguration _configuration;

        public AccountService(IUserRepository repository, IMapper mapper, IPasswordHasher<User> hasher, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _hasher = hasher;
            _configuration = configuration;
        }
        public async Task<UserDisplayDto> CreateAsync(UserCreateDto dto)
        {
            if (!await _repository.CheckIfExistsAsync<Role>(r => r.Id == dto.RoleId))
                throw new BadHttpRequestException($"Role with id {dto.RoleId} doesn't exist.");

            var user = _mapper.Map<User>(dto);
            user.PasswordHash = _hasher.HashPassword(user, dto.Password);

            _repository.Create(user);
            await _repository.SaveChangesAsync();
            return _mapper.Map<UserDisplayDto>(user);
        }

        public async Task<string> LoginUserAsync(UserLoginDto inputDto)
        {
            var user = await _repository.GetSingleByConditionWithRelatedEntityAsync(u => u.Login == inputDto.Login, "Role");
            var passwordMatches = _hasher.VerifyHashedPassword(user, user.PasswordHash, inputDto.Password);

            if (passwordMatches == PasswordVerificationResult.Failed)
                throw new BadHttpRequestException("Incorrect user email or password.");

            return GenerateJwt(user);
        }

        private string GenerateJwt(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:JwtKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            double.TryParse(_configuration["Authentication:JwtExpireMinutes"], out double minutes);

            var expires = DateTime.Now.AddMinutes(minutes);

            var token = new JwtSecurityToken(
                _configuration["Authentication:JwtIssuer"],
                _configuration["Authentication:JwtAudience"],
                claims,
                expires: expires,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
