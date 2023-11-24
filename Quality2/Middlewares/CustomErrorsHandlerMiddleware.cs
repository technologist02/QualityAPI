using Quality2.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System;
using NLog;
using Microsoft.Extensions.Logging;

namespace Quality2.Middlewares
{
    public class CustomErrorsHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomErrorsHandlerMiddleware> logger;

        public CustomErrorsHandlerMiddleware(RequestDelegate next, ILogger<CustomErrorsHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
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
                var trace = exc.StackTrace;
                logger.LogError("Ошибка \n{trace}", trace);
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
