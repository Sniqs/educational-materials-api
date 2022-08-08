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
        public async Task<IEnumerable<MaterialDisplayDto>> GetAllAsync()
        {
            var materials = await _repository.GetAllReadOnlyWithRelatedEntityAsync("Reviews");
            return _mapper.Map<IEnumerable<MaterialDisplayDto>>(materials);
        }
    }
}
