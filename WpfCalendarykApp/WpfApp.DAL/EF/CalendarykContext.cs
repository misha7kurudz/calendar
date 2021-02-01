using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.VisualBasic;
using WpfApp.DAL.Entities;

namespace WpfApp.DAL.EF
{
    public class CalendarykContext : DbContext
    {
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }

        public CalendarykContext()
        {
        }

        /// <summary>
        /// Create database if it doesn't exist.
        /// </summary>
        public CalendarykContext(DbContextOptions<CalendarykContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        /// <summary>
        /// Configure connection string.
        /// </summary>
        /// <param name="optionsBuilder">Service for configuration</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Calendaryk;Trusted_Connection=True;");
        }

        /// <summary>
        /// Configuration for relation one-to-many
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var calendars = new List<Calendar>
            {
                new Calendar {Id = 1, Title = "Holidays"}
            };

            var events = new List<Event>
            {
                new Event
                {
                    EventId = 1, CalendarId = 1, Description = "Description1", StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(2), Notification = DateTime.Now.AddDays(1)
                },

                new Event
                {
                    EventId = 2, CalendarId = 1, Description = "Description2", StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(5), Notification = DateTime.Now.AddDays(2).AddHours(3)
                },

                new Event
                {
                    EventId = 3, CalendarId = 1, Description = "Description3", StartTime = DateTime.Now.AddDays(2),
                    EndTime = DateTime.Now.AddDays(1).AddMinutes(40), Notification = DateTime.Now.AddDays(5).AddHours(3)
                }
            };

            var roles = new List<ApplicationRole>
            {
                new ApplicationRole {Id = 1, Type = "user"},
                new ApplicationRole {Id = 2, Type = "admin"}
            };

            var users = new List<ApplicationUser>
            {
                new ApplicationUser {Id = 1, Email = "user@lnu.edu.ua", Password = "user", RoleId = 1},
                new ApplicationUser {Id = 2, Email = "admin@lnu.edu.ua", Password = "admin", RoleId = 2}
            };

            modelBuilder.Entity<Calendar>().HasData(calendars);
            modelBuilder.Entity<Event>().HasData(events);
            modelBuilder.Entity<ApplicationUser>().HasData(users);
            modelBuilder.Entity<ApplicationRole>().HasData(roles);
        }
    }
}
