﻿using Quality2.Exceptions;
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
            switch (exception)
            {
                case BadRequestException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case NotFoundException notFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;

                    break;
            }

            return context.Response.WriteAsJsonAsync(exception.Errors);
        }
    }
}
