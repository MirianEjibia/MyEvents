using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseCases.Events.DTOs
{
    public class EditEventDto: BaseEventDto
    {
        public required string Id {get;set;}
    }
}