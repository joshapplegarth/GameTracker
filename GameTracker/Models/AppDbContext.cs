using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTracker.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User>     User     { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Game>     Game     { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();


            // U S E R S --------------------------------------------------------
            //modelBuilder.Entity<User>().HasData
            //    (new User
            //    {
            //        Id = 1,
            //        Firstname = "Joshua",
            //        Lastname = "Applegarth",
            //        Email = "j.applegarth@Example.com",
            //        Password = "qazQAZ1!",
            //        IsAdmin = true,
            //    }
            //    );
            //modelBuilder.Entity<User>().HasData
            //    (new User
            //    {
            //        Id = 2,
            //        Firstname = "Chris",
            //        Lastname = "Mathews",
            //        Email = "c.mathews@Example.com",
            //        Password = "wsxWSX2@",
            //        IsAdmin = false,
            //
            //    }
            //    );
            //modelBuilder.Entity<User>().HasData
            //    (new User
            //    {
            //        Id = 3,
            //        Firstname = "Wayne",
            //        Lastname = "Walker",
            //        Email = "w.walker@Example.com",
            //        Password = "edcEDC3#",
            //        IsAdmin = false,
            //
            //    }
            //    );
            //modelBuilder.Entity<User>().HasData
            //    (new User
            //    {
            //        Id = 4,
            //        Firstname = "Sergio",
            //        Lastname = "Aguirre",
            //        Email = "s.aguirre@Example.com",
            //        Password = "rfvRFV4$",
            //        IsAdmin = false,
            //    }
            //    );
            //modelBuilder.Entity<User>().HasData
            //    (new User
            //    {
            //        Id = 5,
            //        Firstname = "Micah",
            //        Lastname = "Thompson",
            //        Email = "m.thompson@Example.com",
            //        Password = "tgbTGB5%",
            //        IsAdmin = false,
            //    }
            //    );

            // L O C A T I O N S ----------------------------------------------------------------

            //modelBuilder.Entity<Location>().HasData
            //    (new Location
            //    {
            //        Id = 1,
            //        City = "Fort Hood",
            //        State = "Texas",
            //        LandOwner = "Government",
            //    }
            //    );
            //modelBuilder.Entity<Location>().HasData
            //    (new Location
            //    {
            //        Id = 2,
            //        City = "Harker Heights",
            //        State = "Texas",
            //        LandOwner = "Randy Rubendaul",
            //    }
            //    );
            //modelBuilder.Entity<Location>().HasData
            //    (new Location
            //    {
            //        Id = 3,
            //        City = "Salado",
            //        State = "Texas",
            //        LandOwner = "Dustin Wilkins",
            //    }
            //    );
            //// G A M E --------------------------------------------------------------------------
            //modelBuilder.Entity<Game>().HasData
            //    (new Game
            //    {
            //        Id = 1,
            //        Type = "Hog",
            //        Gender = "Male",
            //        Weight = 200,
            //        Date = "20210508",
            //
            //    }
            //    );
            //modelBuilder.Entity<Game>().HasData
            //    (new Game
            //    {
            //        Id = 2,
            //        Type = "Hog",
            //        Gender = "Female",
            //        Weight = null,
            //        Date = "20210507",
            //
            //    }
            //    );
            //modelBuilder.Entity<Game>().HasData
            //    (new Game
            //    {
            //        Id = 3,
            //        Type = "Turkey",
            //        Gender = "Male",
            //        Weight = 25,
            //        Date = "20210404",
            //
            //    }
            //    );

        }
    }
}
