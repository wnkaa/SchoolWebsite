using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
/*
    * Model class Specie
    * Relations:
    *  Many to many: *
    *  One to many: Przedmiot(Each Specie can have many Products)
    */ 
namespace SchoolWebsite.Models
{
    public class Specie
    {
        public Specie()
        {
            Przedmioty = new List<Przedmiot>();
        }
        public int SpecieID { get; set; }
        [Required(ErrorMessage="Name is required")]
        [StringLength(20, ErrorMessage = "Maximum length 20")]
        public string Name { get; set; }

        public int PrzedmiotID { get; set; }
        public virtual ICollection<Przedmiot> Przedmioty { get; set; }

    }
}