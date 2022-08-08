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
    }
}
