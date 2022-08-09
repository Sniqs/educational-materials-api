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

        /// <summary>
        /// Gets a list of all the material types.
        /// </summary>
        /// <returns>All material types.</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<MaterialTypeDisplayDto>))]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// Gets data of a single material type.
        /// </summary>
        /// <param name="typeId">Identifier of the material type to return.</param>
        /// <returns>Data of the specified material type.</returns>
        [HttpGet("{typeId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialTypeDisplayDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSingleAsync(int typeId)
            => Ok(await _service.GetSingleAsync(typeId));

        /// <summary>
        /// Gets a list of materials of the given type.
        /// </summary>
        /// <param name="typeId">Identifier of the type of materials to return.</param>
        /// <returns>All materials of the given type.</returns>
        [HttpGet("{typeId}/materials")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<MaterialDisplayDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMaterialsOfTypeAsync(int typeId)
            => Ok(await _service.GetTypeMaterialsAsync(typeId));
    }
}
