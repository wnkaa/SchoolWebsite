using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace SchoolWebsite.Models
{
    //DB context class. Used to get and store data from db.//
    public class Context:DbContext
    {
        public Context()
            : base("SchoolDBConnectionString")
        {

        }
      public DbSet<Lector> Lectors { get; set; }
      public DbSet<Przedmiot> Przedmioty { get; set; }
      public DbSet<Specie> Species { get; set; }
      public DbSet<Course> Courses { get; set; }
      public DbSet<User> Users { get; set; }

    }
}