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

        public async Task<MaterialDisplayDto> GetSingleAsync(int id)
        {
            var material = await _repository.GetSingleByConditionWithRelatedEntityAsync(m => m.Id == id, "Reviews");
            return _mapper.Map<MaterialDisplayDto>(material);
        }
    }
}
