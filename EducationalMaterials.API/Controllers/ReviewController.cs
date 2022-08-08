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

    }
}
