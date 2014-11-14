using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebsite.Models
{
    public interface IRepository<Type> where Type : class
    {
        IQueryable<Type> GetAll();
        Type Get(int id);
        void Add(Type entity);
        void Delete(int id);
        void Edit(Type entity);
    }
}
