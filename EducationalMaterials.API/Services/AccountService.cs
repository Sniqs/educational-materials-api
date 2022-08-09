namespace EducationalMaterials.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _hasher;

        public AccountService(IUserRepository repository, IMapper mapper, IPasswordHasher<User> hasher)
        {
            _repository = repository;
            _mapper = mapper;
            _hasher = hasher;
        }
        public async Task<UserDisplayDto> CreateAsync(UserCreateDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.PasswordHash = _hasher.HashPassword(user, dto.Password);

            _repository.Create(user);
            await _repository.SaveChangesAsync();
            return _mapper.Map<UserDisplayDto>(user);
        }
    }
}
