namespace EducationalMaterials.API.Controllers
{
    [ApiController]
    [Route("api/material-types")]
    public class MaterialTypeController : ControllerBase
    {
        private readonly IMaterialTypeService _service;

        public MaterialTypeController(IMaterialTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{typeId}")]
        public async Task<IActionResult> GetSingleAsync(int typeId)
            => Ok(await _service.GetSingleAsync(typeId));

        [HttpGet("{typeId}/materials")]
        public async Task<IActionResult> GetMaterialsOfTypeAsync(int typeId)
            => Ok(await _service.GetTypeMaterialsAsync(typeId));
    }
}
