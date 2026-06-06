using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Validation;

namespace API.Middlwares
{
    public class ExceptionMiddleware : IMiddleware
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
                Console.WriteLine(ex.ToString()); 
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