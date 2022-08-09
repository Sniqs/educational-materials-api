namespace EducationalMaterials.API.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        /// <summary>
        /// Creates a user based on provided data.
        /// </summary>
        /// <param name="inputDto">Data of the user to create.</param>
        /// <returns>Data of the created user.</returns>
        [HttpPost("register")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(UserDisplayDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterUserAsync(UserCreateDto inputDto)
        {
            var addedUserDto = await _service.CreateAsync(inputDto);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{addedUserDto.Id}", addedUserDto);
        }

        /// <summary>
        /// Logs a user in based on the provided data.
        /// </summary>
        /// <param name="inputDto">User login data.</param>
        /// <returns>JWT for the given user.</returns>
        [HttpPost("login")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Text.Plain)]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUserAsync(UserLoginDto inputDto)
            => Ok(await _service.LoginUserAsync(inputDto));
    }
}
