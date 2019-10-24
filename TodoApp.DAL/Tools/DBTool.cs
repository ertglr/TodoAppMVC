using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DAL.Context;

namespace TodoApp.DAL.Tools
{
    public static class DBTool
    {
        public static TodoContext db;

        public static TodoContext ProjectContext
        {
            get
            {
                if (db==null)
                {
                    db = new TodoContext();
                }
                return db;
            }
        }
    }
}
