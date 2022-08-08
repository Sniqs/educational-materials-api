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
        public async Task<IActionResult> Create(ReviewCreateDto inputDto)
        {
            var addedReviewDto = await _service.CreateAsync(inputDto);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{addedReviewDto.Id}", addedReviewDto);
        }
    }
}
