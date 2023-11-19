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
            catch (CustomException exception)
            {
                await HandleExceptionAsync(context, exception);
            }
            catch (Exception exc)
            {
                throw;
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, CustomException exception)
        {
            var result = string.Empty;
            switch (exception)
            {
                case BadRequestException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result = validationException.Message;
                    break;
                case NotFoundException notFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    result = notFoundException.Message;
                    break;
            }
            //context.Response.ContentType = "application/json";

            //if (result == string.Empty)
            //{
            //    result = JsonSerializer.Serialize(new { error = exception.Message });
            //}
            //using var writer = new StringWriter();
            //var res = string.Empty;
            //res = JsonSerializer.Serialize(exception.Errors);
            //context.Response.Body = await writer.WriteAsync(res)
            return context.Response.WriteAsJsonAsync(exception.Errors);
            //return context.Response.WriteAsync(res);
        }
    }
}
