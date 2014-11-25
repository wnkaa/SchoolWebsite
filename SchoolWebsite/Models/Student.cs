using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolWebsite.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //one to one user - student
        [Key, ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }

    }
}