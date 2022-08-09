namespace EducationalMaterials.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void RegisterCustomMiddleware(this WebApplication app)
        {
            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
