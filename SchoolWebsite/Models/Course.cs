using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SchoolWebsite.Models
{/*
  * Model class for course
  * Relations:
  *     Many to many: Lectors, Przedmiot
  *     One to many: *
  */

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
        [Required(ErrorMessage="Name is required")]
        [StringLength(20,ErrorMessage="Maximum length 20")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Limit is required")]
        public int PeopleLimit { get; set; }
        public virtual ICollection<Lector> Lectors { get; set; }
        public virtual ICollection<Przedmiot> Przedmioty { get; set; }
    }
}
