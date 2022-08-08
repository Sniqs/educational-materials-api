namespace EducationalMaterials.API.Controllers
{
    [ApiController]
    [Route("api/types")]
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
    }
}
