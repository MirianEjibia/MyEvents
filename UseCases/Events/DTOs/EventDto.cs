using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using UseCases.Profiles.DTOs;

namespace UseCases.Events.DTOs
{
    public class EventDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCancelled { get; set; }

        public required string Country { get; set; }
        public required string City { get; set; }
        public double  Parallel {get;set;}
        public double Meridian {get; set;}
        public required string HostName {get;set;}
        public required string HostId {get;set;}
        public List<UserProfileDto> Participants {get;set;} = [];
    }
}