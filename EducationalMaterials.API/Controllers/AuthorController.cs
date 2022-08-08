namespace EducationalMaterials.API.Controllers
{
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetSingleAsync(int authorId)
            => Ok(await _service.GetSingleAsync(authorId));

        [HttpGet("{authorId}/best-materials")]
        public async Task<IActionResult> GetBestMaterialsAsync(int authorId)
            => Ok(await _service.GetBestMaterialsAsync(authorId));
    }
}
