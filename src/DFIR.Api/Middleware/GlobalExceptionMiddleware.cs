using DFIR.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DFIR.Api.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
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
            catch (Exception exception)
            {
                await HandleExceptionAsync(
                    context,
                    exception);
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            var traceId = context.TraceIdentifier;

            _logger.LogError(
                exception,
                "Unhandled exception. TraceId: {TraceId}",
                traceId);

            var statusCode = exception switch
            {
                ValidationException =>
                    StatusCodes.Status400BadRequest,

                UnsupportedFileFormatException =>
                    StatusCodes.Status400BadRequest,

                FileNotFoundException =>
                    StatusCodes.Status404NotFound,

                UnauthorizedAccessException =>
                    StatusCodes.Status403Forbidden,

                _ =>
                    StatusCodes.Status500InternalServerError
            };

            var title = exception switch
            {
                ValidationException =>
                    "Validation Error",

                UnsupportedFileFormatException =>
                    "Unsupported File Format",

                FileNotFoundException =>
                    "File Not Found",

                UnauthorizedAccessException =>
                    "Access Denied",

                _ =>
                    "Internal Server Error"
            };

            var detail = statusCode == StatusCodes.Status500InternalServerError
                ? "An unexpected error occurred while processing the request."
                : exception.Message;

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/problem+json";

            var response = new
            {
                type = $"https://httpstatuses.com/{statusCode}",
                title,
                status = statusCode,
                detail,
                traceId
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}
