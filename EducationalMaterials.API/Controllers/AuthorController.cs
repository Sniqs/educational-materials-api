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

        /// <summary>
        /// Gets a list of all the authors.
        /// </summary>
        /// <returns>All authors.</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<AuthorDisplayDto>))]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// Gets data of a single author.
        /// </summary>
        /// <param name="authorId">Identifier of the author to return.</param>
        /// <returns>Data of the specified author.</returns>
        [HttpGet("{authorId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AuthorDisplayDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSingleAsync(int authorId)
            => Ok(await _service.GetSingleAsync(authorId));

        /// <summary>
        /// Gets all the materials of a single author that have an average rating of above 5.
        /// </summary>
        /// <param name="authorId">Identifier of the author whose materials you want to get.</param>
        /// <returns>All materials of the given author with an average rating of above 5.</returns>
        [HttpGet("{authorId}/best-materials")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<MaterialDisplayDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBestMaterialsAsync(int authorId)
            => Ok(await _service.GetBestMaterialsAsync(authorId));
    }
}
