using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolWebsite.Models
{
    public class Course
    {
        public Course()
        {
            Lectors = new HashSet<Lector>();
            Przedmioty = new HashSet<Przedmiot>();
        }
        public int CourseID { get; set; }
        public int LectorID { get; set; }
        public int PrzedmiotID { get; set; }
        public string Name { get; set; }
        public int PeopleLimit { get; set; }
        public virtual ICollection<Lector> Lectors { get; set; }
        public virtual ICollection<Przedmiot> Przedmioty { get; set; }
    }
}
