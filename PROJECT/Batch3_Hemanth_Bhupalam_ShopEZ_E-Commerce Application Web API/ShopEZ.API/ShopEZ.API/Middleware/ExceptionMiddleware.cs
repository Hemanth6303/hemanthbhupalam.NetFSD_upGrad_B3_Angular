using System.Net;
using System.Text.Json;

namespace ShopEZ.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            // Customize based on exception type
            if (ex.Message.Contains("not found"))
                statusCode = HttpStatusCode.NotFound;

            else if (ex.Message.Contains("Invalid") || ex.Message.Contains("Quantity"))
                statusCode = HttpStatusCode.BadRequest;

            else if (ex.Message.Contains("Unauthorized"))
                statusCode = HttpStatusCode.Unauthorized;

            var response = new
            {
                statusCode = (int)statusCode,
                message = ex.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}