using System;
using Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext(DbContextOptions options): IdentityDbContext<User>(options)
{
     public required DbSet<Event> Events{ get; set; }    
} 