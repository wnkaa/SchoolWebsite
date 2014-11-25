using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebsite.Models
{
    /*
     * Generic interface used to manage data for every model class
     * 
     */ 
    public interface IRepository<Type>:IDisposable where Type : class 
    {
        IQueryable<Type> GetAll();
        Type Get(int? id);
        void Add(Type entity);
        void Delete(Type entity);
        void Edit(Type entity,int id);
        
    }
}
