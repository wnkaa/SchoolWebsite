using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
namespace SchoolWebsite.Models
{
    public class RepositoryT<Type>: IRepository<Type> where Type : class
    {
        private readonly DbSet<Type> Dbset;
        public RepositoryT(DbContext ctx)
        {
            Dbset = ctx.Set<Type>();
        }
        public IQueryable<Type> GetAll() 
        {
            return Dbset;
        }

        public Type Get(int id)
        {
            return Dbset.Find(id);
        }

        public void Add(Type entity)
        {
            Dbset.Add(entity);
        }

        public void Delete(int id)
        {
            
        }

        public void Edit(Type entity)
        {
            throw new NotImplementedException();
        }
    }
}