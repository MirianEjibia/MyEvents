using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Core
{
    public class User: IdentityUser
    {
        public string? DispalyName { get; set; }
        public string? ImageUrl {get;set;}
        public string? UserInfo {get;set;}
    }
}