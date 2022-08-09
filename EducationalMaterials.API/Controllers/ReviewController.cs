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

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReviewDisplayDto>))]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{reviewId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ReviewDisplayDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSingleAsync(int reviewId)
            => Ok(await _service.GetSingleAsync(reviewId));

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
