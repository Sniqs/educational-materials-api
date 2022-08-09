namespace EducationalMaterials.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public AccountService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserDisplayDto> CreateAsync(UserCreateDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _repository.Create(user);
            await _repository.SaveChangesAsync();
            return _mapper.Map<UserDisplayDto>(user);
        }
    }
}
