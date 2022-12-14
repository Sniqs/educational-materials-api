using Microsoft.AspNetCore.Components.Forms;

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

        /// <summary>
        /// Gets a list of all the materials.
        /// </summary>
        /// <returns>All materials.</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<MaterialDisplayDto>))]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// Gets data of a single material.
        /// </summary>
        /// <param name="materialId">Identifier of the material to return.</param>
        /// <returns>Data of the specified material.</returns>
        [HttpGet("{materialId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialDisplayDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetSingleAsync(int materialId)
            => Ok(await _service.GetSingleAsync(materialId));

        /// <summary>
        /// Creates a material based on provided data.
        /// </summary>
        /// <param name="inputDto">Data of the material to create.</param>
        /// <returns>Data of the created material.</returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(MaterialDisplayDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync(MaterialCreateDto inputDto)
        {
            var addedMaterialDto = await _service.CreateAsync(inputDto);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{addedMaterialDto.Id}", addedMaterialDto);
        }

        /// <summary>
        /// Updates a material based on provided data.
        /// </summary>
        /// <param name="inputDto">New material data.</param>
        /// <param name="materialId">Identifier of the material to update.</param>
        /// <returns>Updated material data.</returns>
        [HttpPut("{materialId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialDisplayDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(MaterialUpdateDto inputDto, int materialId)
        {
            if (inputDto.Id != materialId) return BadRequest("Different resource id in URL and request body");
            var updatedMaterialDto = await _service.UpdateAsync(inputDto);
            return Ok(updatedMaterialDto);
        }

        /// <summary>
        /// Partially updates a material based on provided data.
        /// </summary>
        /// <param name="patchDoc">JSON patch document with material data to change.</param>
        /// <param name="materialId">Identifier of the material to partially update.</param>
        /// <returns>Updated material data.</returns>
        [HttpPatch("{materialId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(MaterialDisplayDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PartiallyUpdateAsync(JsonPatchDocument<MaterialUpdateDto> patchDoc, int materialId)
        {
            var materialUpdateDto = await _service.GetUpdateDtoForPatch(materialId);

            patchDoc.ApplyTo(materialUpdateDto, ModelState);
            if (!TryValidateModel(materialUpdateDto)) return ValidationProblem(ModelState);

            return Ok(await _service.UpdateAsync(materialUpdateDto));
        }

        /// <summary>
        /// Deletes a specified material.
        /// </summary>
        /// <param name="materialId">Identifier of the material to delete.</param>
        [HttpDelete("{materialId}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int materialId)
        {
            await _service.DeleteAsync(materialId);
            return NoContent();
        }
    }
}
