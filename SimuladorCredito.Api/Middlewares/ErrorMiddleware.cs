using System.Text.Json;
using SimuladorCredito.Domain.Exceptions.HttpExceptions;

namespace SimuladorCredito.Api.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorMiddleware> _logger;

        public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Houve um error");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(exception);

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Ocorreu um erro no servidor",
                Detail = exception.Message
            };

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }

        private static int GetStatusCode(Exception ex)
        {
            if (ex is NotFoundException) return StatusCodes.Status404NotFound;
            if (ex is BadRequestException) return StatusCodes.Status400BadRequest;

            return StatusCodes.Status500InternalServerError;
        }
    }
}
