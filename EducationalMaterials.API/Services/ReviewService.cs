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

        public async Task<ReviewDisplayDto> CreateAsync(ReviewCreateDto dto)
        {
            if (!await _repository.CheckIfExists<Material>(m => m.Id == dto.MaterialId))
                throw new BadHttpRequestException($"Material with id {dto.MaterialId} doesn't exist.");

            var review = _mapper.Map<Review>(dto);
            _repository.Create(review);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ReviewDisplayDto>(review);
        }

        public async Task DeleteAsync(int id)
        {
            var review = await _repository.GetSingleByConditionAsync(r => r.Id == id);
            _repository.Delete(review);
            await _repository.SaveChangesAsync();
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

        public async Task<ReviewDisplayDto> UpdateAsync(ReviewUpdateDto dto)
        {
            var review = await _repository.GetSingleByConditionAsync(r => r.Id == dto.Id);
            _mapper.Map(dto, review);
            _repository.Update(review);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ReviewDisplayDto>(review);
        }
    }
}
