using System;
using FluentValidation;
using UseCases.Events.Commands;
using UseCases.Events.DTOs;


namespace UseCases.Events.Validators
{
    public class CreateEventValidator: AbstractValidator<CreateEvent.Command>
    {
        public CreateEventValidator()
        {
            RuleFor(x => x.EventDto.Name).NotEmpty().WithMessage("Name in required");
            RuleFor(x => x.EventDto.Country).NotEmpty().WithMessage("Country in required");
        }
    }
}