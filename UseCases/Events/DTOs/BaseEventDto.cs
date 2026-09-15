using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseCases.Events.DTOs
{
    public class BaseEventDto
    {
        public string Name { get; set; } = "";
        public string Description { get; set; }= "";
        public DateTime StartDate { get; set; }
        public string Country { get; set; } = "";
        public string City { get; set; } = "";
        public double  Parallel {get;set;}
        public double Meridian {get; set;}
    }
}