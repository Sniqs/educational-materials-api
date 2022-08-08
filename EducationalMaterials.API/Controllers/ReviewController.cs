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
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{reviewId}")]
        public async Task<IActionResult> GetSingleAsync(int reviewId)
            => Ok(await _service.GetSingleAsync(reviewId));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ReviewCreateDto inputDto)
        {
            var addedReviewDto = await _service.CreateAsync(inputDto);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{addedReviewDto.Id}", addedReviewDto);
        }

        [HttpPut("{reviewId}")]
        public async Task<IActionResult> UpdateAsync(ReviewUpdateDto inputDto, int reviewId)
        {
            if (inputDto.Id != reviewId) return BadRequest("Different resource id in URL and request body");
            var updatedReviewDto = await _service.UpdateAsync(inputDto);
            return Ok(updatedReviewDto);
        }

        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteAsync(int reviewId)
        {
            await _service.DeleteAsync(reviewId);
            return NoContent();
        }
    }
}
