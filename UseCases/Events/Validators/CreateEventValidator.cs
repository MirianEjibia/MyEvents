using System;
using FluentValidation;
using UseCases.Events.Commands;
using UseCases.Events.DTOs;


namespace UseCases.Events.Validators
{
    public class CreateEventValidator: BaseEventValidator<CreateEvent.Command,CraeteEventDto>
    {
        public CreateEventValidator() : base (x=>x.EventDto)
        {
        }
    }
}