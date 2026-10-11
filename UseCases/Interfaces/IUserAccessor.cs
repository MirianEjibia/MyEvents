using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace UseCases.Interfaces
{
    public interface IUserAccessor
    {
         string GetUserId();
         Task<User> GetUserAsync();
    }
}