using System;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext(DbContextOptions options): DbContext(options)
{
     public required DbSet<Event> Events{ get; set; }    
} 