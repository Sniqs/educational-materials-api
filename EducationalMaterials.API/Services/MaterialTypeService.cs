namespace EducationalMaterials.API.Services
{
    public class MaterialTypeService : IMaterialTypeService
    {
        private readonly IMaterialTypeRepository _repository;
        private readonly IMapper _mapper;

        public MaterialTypeService(IMaterialTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MaterialTypeDisplayDto>> GetAllAsync()
        {
            var materialTypes = await _repository.GetAllReadOnlyAsync();
            return _mapper.Map<IEnumerable<MaterialTypeDisplayDto>>(materialTypes);
        }

        public async Task<MaterialTypeDisplayDto> GetSingleAsync(int id)
        {
            var materialType = await _repository.GetSingleByConditionAsync(r => r.Id == id);
            return _mapper.Map<MaterialTypeDisplayDto>(materialType);
        }

        public async Task<IEnumerable<MaterialDisplayDto>> GetTypeMaterialsAsync(int id)
        {
            if (!await _repository.CheckIfExistsAsync<MaterialType>(t => t.Id == id))
                throw new BadHttpRequestException($"Material type with id {id} doesn't exist.");

            var materials = await _repository.GetTypeMaterialsAsync(id);
            return _mapper.Map<IEnumerable<MaterialDisplayDto>>(materials);
        }
    }
}
