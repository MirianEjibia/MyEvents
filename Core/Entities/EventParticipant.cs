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
        public User User {get;set;}
        public int UserId {get;set;}
        public Event Event {get;set;}
        public int EventId {get;set;}
  
        
    }
}