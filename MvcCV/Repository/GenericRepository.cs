using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcCV.Models.Entity;

namespace MvcCV.Repository
{
    public class GenericRepository<T> where T : class ,new()
    {
          DbCVEntities db = new DbCVEntities();
          
        public List<T> List() { 
          
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
    }
}