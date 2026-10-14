using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseCases.Profiles.DTOs
{
    public class UserProfileDto
    {
        public required string Id { get; set;}
        public required string UserName { get; set; }
        public string? ImageUrl { get; set; }
    }
}