using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User: IdentityUser
    {
        public string? DispalyName { get; set; }
        public string? ImageUrl {get;set;}
        public string? UserInfo {get;set;}
        public ICollection<EventParticipant> Events{get;set;} = [];
    }
}