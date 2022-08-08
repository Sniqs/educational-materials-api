namespace EducationalMaterials.API.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AuthorDisplayDto>> GetAllAsync()
        {
            var authors = await _repository.GetAllReadOnlyWithRelatedEntityAsync("Materials");
            return _mapper.Map<IEnumerable<AuthorDisplayDto>>(authors);
        }
    }
}
