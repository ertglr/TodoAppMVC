using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.BLL.Repository
{
    interface IRepository<T> where T:class
    {
        void Inser(T item);
        void Update(T item);
        void Delete(Guid id);
        List<T> SelectAll();
        T SelectById(Guid id);
    }
}
