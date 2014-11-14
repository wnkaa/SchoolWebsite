using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebsite.Models
{
    public interface ILectorsRepository
    {
        IQueryable<Lector> GetAll();
        Lector Get(int id);
        void Add(Lector lector);
        void Delete(int id);
        void Edit(Lector lector);
    }
}
