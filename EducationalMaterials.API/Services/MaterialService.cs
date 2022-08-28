namespace EducationalMaterials.API.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _repository;
        private readonly IMapper _mapper;

        public MaterialService(IMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MaterialDisplayDto> CreateAsync(MaterialCreateDto dto)
        {
            await CheckIfAuthorAndTypeExistAsync(dto.AuthorId, dto.TypeId);

            var material = _mapper.Map<Material>(dto);
            _repository.Create(material);
            await _repository.SaveChangesAsync();
            return _mapper.Map<MaterialDisplayDto>(material);
        }

        public async Task DeleteAsync(int id)
        {
            var review = await _repository.GetSingleByConditionAsync(r => r.Id == id);
            _repository.Delete(review);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<MaterialDisplayDto>> GetAllAsync()
        {
            var materials = await _repository.GetAllReadOnlyWithRelatedEntityAsync(Includes.Reviews.ToString());
            return _mapper.Map<IEnumerable<MaterialDisplayDto>>(materials);
        }

        public async Task<MaterialDisplayDto> GetSingleAsync(int id)
        {
            var material = await _repository.GetSingleByConditionWithRelatedEntityAsync(m => m.Id == id, Includes.Reviews);
            return _mapper.Map<MaterialDisplayDto>(material);
        }

        public async Task<MaterialDisplayDto> UpdateAsync(MaterialUpdateDto dto)
        {
            await CheckIfAuthorAndTypeExistAsync(dto.AuthorId, dto.TypeId);

            var material = await _repository.GetSingleByConditionWithRelatedEntityAsync(r => r.Id == dto.Id, Includes.Reviews);
            _mapper.Map(dto, material);
            _repository.Update(material);
            await _repository.SaveChangesAsync();
            return _mapper.Map<MaterialDisplayDto>(material);
        }

        private async Task CheckIfAuthorAndTypeExistAsync(int authorId, int typeId)
        {
            if (!await _repository.CheckIfExistsAsync<Author>(m => m.Id == authorId))
                throw new BadHttpRequestException($"Author with id {authorId} doesn't exist.");

            if (!await _repository.CheckIfExistsAsync<MaterialType>(t => t.Id == typeId))
                throw new BadHttpRequestException($"Material type with id {typeId} doesn't exist.");
        }
    }
}
