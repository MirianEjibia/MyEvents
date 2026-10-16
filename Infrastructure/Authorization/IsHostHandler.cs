using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Authorization
{
    public class IsHostRequirement: IAuthorizationRequirement
    {
    }

    public class IsHostHandler(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) 
        : AuthorizationHandler<IsHostRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsHostRequirement requirement)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return;
            var httpContext = httpContextAccessor.HttpContext;
            if(httpContext?.GetRouteValue("id") is not string eventId ) return;
            var participant = await dbContext.EventParticipants.SingleOrDefaultAsync(x => x.UserId == userId && x.EventId == eventId);
            if(participant == null) return;
            if(participant.IsHost) context.Succeed(requirement);
        }
    }
}