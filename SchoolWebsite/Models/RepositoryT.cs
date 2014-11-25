using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
namespace SchoolWebsite.Models
{
    /*
     * Generic repository class to make all that CRUD stuff 
     */
    public class RepositoryT<Type>: IRepository<Type> where Type : class
    {
        private readonly DbSet<Type> Dbset;
        private readonly DbContext ctx;
        public RepositoryT(DbContext ctx)
        {
            Dbset = ctx.Set<Type>();
            this.ctx = ctx;
        }
        public IQueryable<Type> GetAll() 
        {
            return Dbset;
        }

        public Type Get(int? id)
        {
            if (id != null)
                return Dbset.Find(id);
            else
                return null;
        }

        public void Add(Type entity)
        {
            ctx.Set<Type>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(Type entity)
        {
            ctx.Set<Type>().Remove(entity);
            ctx.SaveChanges();
        }

        public void Edit(Type entity,int id)
        {
            Type druga = Get(id);
            ctx.Entry(druga).CurrentValues.SetValues(entity);
           // ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}