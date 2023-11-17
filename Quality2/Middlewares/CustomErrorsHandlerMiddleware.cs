using Quality2.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System;

namespace Quality2.Middlewares
{
    public class CustomErrorsHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public CustomErrorsHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (exception)
            {
                case BadRequestException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = validationException.Message;
                    break;
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    result = notFoundException.Message;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
