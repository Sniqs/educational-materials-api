namespace EducationalMaterials.API.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewDisplayDto>> GetAllAsync()
        {
            var reviews = await _repository.GetAllReadOnlyAsync();
            return _mapper.Map<IEnumerable<ReviewDisplayDto>>(reviews);
        }

        public async Task<ReviewDisplayDto> GetSingleAsync(int id)
        {
            var review = await _repository.GetSingleByConditionAsync(r => r.Id == id);
            return _mapper.Map<ReviewDisplayDto>(review);
        }
    }
}
