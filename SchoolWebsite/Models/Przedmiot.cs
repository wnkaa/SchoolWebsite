using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebsite.Models
{
    
    public class Przedmiot
    {
       
        
        public int PrzedmiotID { get; set; }
        public string Name { get; set; }

        public int SpecieID { get; set; }
        public virtual Specie Specie { get; set; }

        public int CourseID { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        //sprawdzam cie 
    }
}