using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Persistence;
using UseCases.Interfaces;

using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Authozation
{
    public class UserAccessor(IHttpContextAccessor httpContextAccessor, ApplicationDbContext applicationDbContext) : IUserAccessor
    {
        public async Task<User> GetUserAsync()
        {
            var userId   = GetUserId();
            return await applicationDbContext.Users.FindAsync(userId) ?? throw new UnauthorizedAccessException();
        }

        public string GetUserId()
        {
            return httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? throw  new Exception("No user found");  ;
        }
    }
}