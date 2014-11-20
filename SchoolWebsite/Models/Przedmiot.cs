using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SchoolWebsite.Models
{
    /*
    * Model class Przedmiot
    * Relations:
    *  Many to many: Courses
    *  One to many: Specie(Each Przedmiot has one Specie)
    */ 
    public class Przedmiot
    {
       
        
        public int PrzedmiotID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Maximum length 20")]
        public string Name { get; set; }

        public int SpecieID { get; set; }
        public virtual Specie Specie { get; set; }

        public int CourseID { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}