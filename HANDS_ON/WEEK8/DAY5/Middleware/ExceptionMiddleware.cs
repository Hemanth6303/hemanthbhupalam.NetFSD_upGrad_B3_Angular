using System.Net;
using System.Text.Json;
using ContactManagement.API.Models;
using ContactManagement.API.Exceptions;

namespace ContactManagement.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred");

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string message = "Something went wrong";

            switch (ex)
            {
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;

                case ValidationException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
            }

            var response = new ErrorResponse
            {
                Message = message,
                StatusCode = (int)statusCode,
                Timestamp = DateTime.UtcNow
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}