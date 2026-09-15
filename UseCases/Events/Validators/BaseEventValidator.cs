using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using UseCases.Events.DTOs;

namespace UseCases.Events.Validators
{
    public class BaseEventValidator<T, DtoT>: AbstractValidator<T>  where DtoT: BaseEventDto
    {
        public BaseEventValidator(Func<T, DtoT> selector)
        {
            RuleFor(x => selector(x).Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => selector(x).Country).NotEmpty().WithMessage("Country in required");
        }
    }
}