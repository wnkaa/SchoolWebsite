using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebsite.Models
{
    public class Lector
    {
        public int LectorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }

        public int CourseID { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}