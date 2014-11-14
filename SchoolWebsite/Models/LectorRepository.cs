using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebsite.Models
{
    public class LectorRepository: IRepository<Lector>
    {
        private readonly Context ctx = new Context();
        public IQueryable<Lector> GetAll()
        {
            IQueryable<Lector> all = ctx.Lectors;
            return all;
        }

        public Lector Get(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.LectorID == id);
            return query;
        }

        public void Add(Lector lector)
        {
            ctx.Lectors.Add(lector);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Lector lector = (Lector)ctx.Lectors.Where(l=>l.LectorID == id);
            ctx.Lectors.Remove(lector);
            ctx.SaveChanges();
        }

        public void Edit(Lector lectorAfter)
        {
            var lectorBefore = ctx.Lectors.Find(lectorAfter.LectorID);
            if (lectorBefore != null)
            {
                ctx.Entry(lectorBefore).CurrentValues.SetValues(lectorAfter);
                ctx.SaveChanges();
            }
              
            
        }
    }
}