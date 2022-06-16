using System;
using System.Linq;
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
            catch (Exception ex)
            {
                //todo добавить логгер
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            int statusCode;
            string errorMessage;

            if (exception is ValidationException validationException)
            {
                statusCode = StatusCodes.Status400BadRequest;

                var validateErrorMessage = errorMessage = validationException
                    .Errors
                    .Values
                    .SelectMany(value => value)
                    .Aggregate((errorMsg1, errorMsg2) => errorMsg1 + ". " + errorMsg2);

                errorMessage = $"Произошла одна или несколько ошибок: {validateErrorMessage}";
            }
            else if (exception is ClientValidationException clientValidationException)
            {
                statusCode = StatusCodes.Status400BadRequest;
                errorMessage = clientValidationException.Message;
            }
            else
            {
                statusCode = StatusCodes.Status500InternalServerError;
                errorMessage = "Произошла ошибка сервера";
            }

            var response = new
            {
                statusCode,
                errorMessage,
                exceptionMessage = exception.Message
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = response.statusCode;
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}