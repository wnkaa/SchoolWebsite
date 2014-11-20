using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SchoolWebsite.Models
{
    /*
     * Model class Lector
     * Relations:
     *  Many to many: Courses
     *  One to many: *
     */ 
    public class Lector
    {
        public int LectorID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Maximum length 20")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        [StringLength(20, ErrorMessage = "Maximum length 20")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(20, ErrorMessage = "Maximum length 20")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Text is required")]
        [StringLength(200, ErrorMessage = "Maximum length 200")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Image URL is required")]
        public string ImageUrl { get; set; }

        public int CourseID { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}