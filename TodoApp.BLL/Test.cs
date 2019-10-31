using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DAL.Context;

namespace TodoApp.BLL
{
    public class Test
    {
        public Test()
        {
            // test
            TodoContext db = new TodoContext();
            db.Users.ToList();
        }
    }
}
