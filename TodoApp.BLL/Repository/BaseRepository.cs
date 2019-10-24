using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DAL.Context;
using TodoApp.DAL.Tools;

namespace TodoApp.BLL.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        TodoContext db = DBTool.ProjectContext;
        public void Delete(Guid id)
        {
            var item = db.Set(typeof(T)).Find(id);
            db.Set(typeof(T)).Remove(item);
            db.SaveChanges();
        }

        public void Inser(T item)
        {
            db.Set(typeof(T)).Add(item);
            db.SaveChanges();
        }

        public List<T> SelectAll()
        {
            return db.Set(typeof(T)).Cast<T>().ToList();
        }

        public T SelectById(Guid id)
        {
            return db.Set(typeof(T)).Cast<T>().Find(id);
        }

        public void Update(T item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
