using Betting.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Data
{
    public class BettingDbContext : DbContext
    {
        public BettingDbContext(DbContextOptions<BettingDbContext> options)
            :base(options)
        {
        }

        public DbSet<EventType> EventTypes { get; set; }
        
        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Betting.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>().ToTable("EventTypes");
            modelBuilder.Entity<EventType>().HasKey(et => et.Id);
            modelBuilder.Entity<EventType>().HasIndex(et => et.Name).IsUnique();
                        
            modelBuilder.Entity<Event>().ToTable("Events");
            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Event>().HasOne(e => e.EventType)
                                        .WithMany(et => et.Events)
                                        .HasForeignKey(e => e.EventTypeId)
                                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}