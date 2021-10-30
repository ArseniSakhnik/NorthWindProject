using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NorthWindProject.Application.Common.Exceptions;

namespace NorthWindProject.Application.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException e)
            {
                //TODO добавить логгер
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            var response = new
            {
                title = GetTitle(exception),
                status = statusCode,
                detail = exception.Message,
                errors = GetErrors(exception)
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                ValidationException => StatusCodes.Status403Forbidden,
                _ => StatusCodes.Status500InternalServerError
            };

        private static string GetTitle(Exception exception) =>
            exception switch
            {
                ValidationException applicationException => applicationException.Message,
                _ => "Ошибка сервера"
            };

        private static IDictionary<string, string[]> GetErrors(Exception exception)
        {
            IDictionary<string, string[]> errors = null;
            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors;
            }

            return errors;
        }
    }
}