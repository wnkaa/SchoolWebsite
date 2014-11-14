using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebsite.Models
{
    public class Specie
    {
        public Specie()
        {
            Przedmioty = new List<Przedmiot>();
        }
        public int SpecieID { get; set; }
        public string Name { get; set; }

        public int PrzedmiotID { get; set; }
        public virtual ICollection<Przedmiot> Przedmioty { get; set; }

    }
}