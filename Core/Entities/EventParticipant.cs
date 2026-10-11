using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Core.Entities
{
    public class EventParticipant
    {
        public DateTime RegisterDate {get;set;}
        public User User {get;set;} = null!;
        public string UserId {get;set;} = null!;
        public Event Event {get;set;} = null!;
        public string EventId {get;set;} = null!;
        public bool IsHost {get;set;}
    }
}