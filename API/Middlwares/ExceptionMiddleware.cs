using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Core;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Validation;

namespace API.Middlwares
{
    public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, IHostEnvironment hostEnv) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch(ValidationException ex)
            {
             await HanldeValidationException(httpContext, ex);
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType= "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                logger.LogError(ex.Message, ex.StackTrace); 
                var res =hostEnv.IsDevelopment() ?  
                    new AppException(StatusCodes.Status500InternalServerError, ex.Message, ex.StackTrace) : 
                    new AppException(StatusCodes.Status500InternalServerError, ex.Message, null);
                
                await httpContext.Response.WriteAsJsonAsync(res);
            }
        }
        private static async Task HanldeValidationException(HttpContext httpContext, ValidationException ex )
        {
            var validationErrors = new Dictionary<string,string[]>();
            foreach (var error in ex.Errors)
            {
                if (validationErrors.TryGetValue(error.PropertyName, out string[]? value))
                {
                    var errors = value.ToList();
                    errors.Add(error.ErrorMessage);
                    validationErrors[error.PropertyName] = [.. errors];
                }
                else
                {
                    validationErrors.Add(error.PropertyName, [error.ErrorMessage]);
                }
            }
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            var validationProblmeDetails = new ValidationProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation error",
                Detail = "one or more validation errros",
                Errors = validationErrors,
                Type ="ValidationError"

            };
             await httpContext.Response.WriteAsJsonAsync(validationProblmeDetails);
        }
    }
}