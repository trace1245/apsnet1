using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ClientId> Clients { get; set; }
        public DbSet<Log> Logfile { get; set; }
        public DbSet<ProfEmails> Profs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

    }
}