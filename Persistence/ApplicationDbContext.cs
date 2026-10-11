using System;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext(DbContextOptions options): IdentityDbContext<User>(options)
{
     public required DbSet<Event> Events{ get; set; }  
     public required DbSet<EventParticipant> EventParticipants { get; set; }    
     protected override void OnModelCreating (ModelBuilder modelBuilder) {
          base.OnModelCreating (modelBuilder);
          modelBuilder.Entity<EventParticipant>(x =>x.HasKey(x=>new { x.UserId, x.EventId }));
          modelBuilder.Entity<EventParticipant>()
               .HasOne(e => e.Event)
               .WithMany(e => e.Participants)
               .HasForeignKey(e => e.EventId);

          modelBuilder.Entity<EventParticipant>()
               .HasOne(e => e.User)
               .WithMany(e => e.Events)
               .HasForeignKey(e => e.UserId);

     }   
} 