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

        public async Task<IEnumerable<MaterialDisplayDto>> GetBestMaterialsAsync(int authorId)
        {
            var authorMaterials = await _repository.GetMaterialsWithReviewsAsync(authorId);

            var bestMaterials = new List<Material>();

            foreach (var material in authorMaterials)
                if (material.AverageRating > 5)
                    bestMaterials.Add(material);

            if (!bestMaterials.Any())
                throw new ResourceNotFoundException("This author has no materials with an average rating of more than 5");

            return _mapper.Map<IEnumerable<MaterialDisplayDto>>(bestMaterials);
        }

        public async Task<AuthorDisplayDto> GetSingleAsync(int id)
        {
            var author = await _repository.GetSingleByConditionWithRelatedEntityAsync(c => c.Id == id, "Materials");
            return _mapper.Map<AuthorDisplayDto>(author);
        }
    }
}
