namespace EducationalMaterials.API.Middleware
{
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next.Invoke(context);

            switch (context.Response.StatusCode)
            {
                case 400:
                    _logger.LogWarning($"Incorrect request: {context.Request.Method} - {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}");
                    break;

                case 401:
                    _logger.LogWarning($"Attempt to access a resource without required authentication");
                    break;

                case 403:
                    _logger.LogWarning($"Attempt to access resource without proper authorization");
                    break;

                default:
                    _logger.LogInformation($"Response status code: {context.Response.StatusCode}");
                    break;
            }
        }
    }
}
