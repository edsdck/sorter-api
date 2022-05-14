namespace Sorter.Api.Extensions
{
    public static class ExceptionHandlingExtensions
    {
        public static WebApplication AddExceptionHandler(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(exceptionHandlerApp =>
                {
                    exceptionHandlerApp.Run(async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = System.Net.Mime.MediaTypeNames.Text.Plain;

                        await context.Response.WriteAsync("Request could not be processed.");
                    });
                });
            }

            return app;
        }
    }
}
