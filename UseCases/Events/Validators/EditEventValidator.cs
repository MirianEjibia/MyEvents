using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using UseCases.Events.Commands;
using UseCases.Events.DTOs;

namespace UseCases.Events.Validators
{
    public class EditEventValidator: BaseEventValidator<UpdateEvent.Command, EditEventDto>
    {
        public EditEventValidator(): base(x=>x.EventDto)
        {
            RuleFor(x => x.EventDto.Id).NotEmpty().WithMessage("");
        }
    }
}