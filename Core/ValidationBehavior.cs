using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;

namespace Core
{
    public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? validator = null)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        async Task<TResponse> IPipelineBehavior<TRequest, TResponse>.Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(validator == null) return await next();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
             throw new ValidationException(validationResult.Errors);
            }
            return await next();
        }
    }
}