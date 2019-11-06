using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DAL.Initializer;
using TodoApp.ENTITIES.EntityClass;

namespace TodoApp.DAL.Context
{
    public class TodoContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TodoContext>(null);

            base.OnModelCreating(modelBuilder);
        }
        //public TodoContext()
        //{
        //    Database.SetInitializer(new TodoInitializer());
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<ENTITIES.EntityClass.Task> Tasks { get; set; }

    }
}
