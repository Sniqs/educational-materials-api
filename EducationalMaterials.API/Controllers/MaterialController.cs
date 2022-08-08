namespace EducationalMaterials.API.Controllers
{
    [ApiController]
    [Route("api/materials")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _service;

        public MaterialController(IMaterialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{materialId}")]
        public async Task<IActionResult> GetSingleAsync(int materialId)
            => Ok(await _service.GetSingleAsync(materialId));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(MaterialCreateDto inputDto)
        {
            var addedMaterialDto = await _service.CreateAsync(inputDto);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{addedMaterialDto.Id}", addedMaterialDto);
        }

        [HttpPut("{materialId}")]
        public async Task<IActionResult> UpdateAsync(MaterialUpdateDto inputDto, int materialId)
        {
            if (inputDto.Id != materialId) return BadRequest("Different resource id in URL and request body");
            var updatedMaterialDto = await _service.UpdateAsync(inputDto);
            return Ok(updatedMaterialDto);
        }

        [HttpDelete("{materialId}")]
        public async Task<IActionResult> DeleteAsync(int materialId)
        {
            await _service.DeleteAsync(materialId);
            return NoContent();
        }
    }
}
