namespace EducationalMaterials.API.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets a list of all the reviews.
        /// </summary>
        /// <returns>All reviews.</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReviewDisplayDto>))]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// Gets data of a single review.
        /// </summary>
        /// <param name="reviewId">Identifier of the review to return.</param>
        /// <returns>Data of the specified review.</returns>
        [HttpGet("{reviewId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ReviewDisplayDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSingleAsync(int reviewId)
            => Ok(await _service.GetSingleAsync(reviewId));

        /// <summary>
        /// Creates a review based on provided data.
        /// </summary>
        /// <param name="inputDto">Data of the review to create.</param>
        /// <returns>Data of the created review.</returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ReviewDisplayDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(ReviewCreateDto inputDto)
        {
            var addedReviewDto = await _service.CreateAsync(inputDto);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{addedReviewDto.Id}", addedReviewDto);
        }

        /// <summary>
        /// Updates a review based on provided data.
        /// </summary>
        /// <param name="inputDto">New review data.</param>
        /// <param name="reviewId">Identifier of the review to update.</param>
        /// <returns>Updated review data.</returns>
        [HttpPut("{reviewId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ReviewDisplayDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(ReviewUpdateDto inputDto, int reviewId)
        {
            if (inputDto.Id != reviewId) return BadRequest("Different resource id in URL and request body");
            var updatedReviewDto = await _service.UpdateAsync(inputDto);
            return Ok(updatedReviewDto);
        }

        /// <summary>
        /// Deletes a specified review.
        /// </summary>
        /// <param name="reviewId">Identifier of the review to delete.</param>
        [HttpDelete("{reviewId}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int reviewId)
        {
            await _service.DeleteAsync(reviewId);
            return NoContent();
        }
    }
}
