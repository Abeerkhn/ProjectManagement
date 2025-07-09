namespace Softwash.Middlewares;

public class ExceptionHandling : IMiddleware
{
    private readonly ILogger<ExceptionHandling> _logger;

    public ExceptionHandling(ILogger<ExceptionHandling> logger)
    {
        _logger = logger;
    }
    public async System.Threading.Tasks.Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
             await next(context);
        }

        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";

            string message = ex.InnerException?.Message ?? ex.Message;

            _logger.LogError(ex, $"A critical error occurred. Error is {message}");
            var result = JsonConvert.SerializeObject(new OutputDTO<dynamic>()
            {
                Succeeded = false,
                HttpStatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                Message = ex.Message,
                Data = null
            });

            await context.Response.WriteAsync(result);
        }
    }
}

