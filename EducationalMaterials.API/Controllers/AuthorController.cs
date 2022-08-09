namespace EducationalMaterials.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<AuthorDisplayDto>))]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{authorId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AuthorDisplayDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSingleAsync(int authorId)
            => Ok(await _service.GetSingleAsync(authorId));

        [HttpGet("{authorId}/best-materials")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<MaterialDisplayDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBestMaterialsAsync(int authorId)
            => Ok(await _service.GetBestMaterialsAsync(authorId));
    }
}
