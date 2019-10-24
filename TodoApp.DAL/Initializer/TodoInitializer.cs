using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DAL.Context;
using TodoApp.ENTITIES.EntityClass;

namespace TodoApp.DAL.Initializer
{
    public class TodoInitializer : CreateDatabaseIfNotExists<TodoContext>
    {
        protected override void Seed(TodoContext context)
        {
            TodoContext db = new TodoContext();


            List<User> users = new List<User>()
            {
                new User(){Firstname="Ertuğrul", Lastname="Güler", Username="ertglr", CreatedOn=DateTime.Now.Date, Email="ertugrul@gmail.com", Password="12345", ConfirmPassword="12345", ModifiedOn=DateTime.Now.AddMinutes(5), ModifiedUser="ertglr"},

                 new User(){Firstname="Murat", Lastname="Başeren", Username="muratbaseren", CreatedOn=DateTime.Now.Date, Email="murat@gmail.com", Password="123456789", ConfirmPassword="123456789", ModifiedOn=DateTime.Now.AddMinutes(5), ModifiedUser="muratbaseren"}

            };

            foreach (var item in users)
            {
                context.Users.Add(item);
            }
            context.SaveChanges();


            List<ENTITIES.EntityClass.Task> tasks = new List<ENTITIES.EntityClass.Task>()
            {
                new ENTITIES.EntityClass.Task() {Text="Bu görev tamamlandı.",  CreatedOn=DateTime.Now.Date.AddDays(-10), IsComleted=true, DueDate=DateTime.Now.Date.AddDays(-5), ModifiedOn=DateTime.Now.Date.AddMinutes(5), Owner=context.Users.FirstOrDefault(i=>i.Email=="ertugrul@gmail.com"), ModifiedUser="ertglr" },
                new ENTITIES.EntityClass.Task(){ Text="Bu görev tamamlandı.",  CreatedOn=DateTime.Now.Date, IsComleted=true,DueDate=DateTime.Now.Date.AddDays(-5), ModifiedOn=DateTime.Now.Date.AddMinutes(5), Owner=context.Users.FirstOrDefault(i=>i.Email=="murat@gmail.com"), ModifiedUser="ertglr" },
                new ENTITIES.EntityClass.Task(){ Text="Bu görev tamamlandı.",  CreatedOn=DateTime.Now.Date.AddDays(-3), IsComleted=true,DueDate=DateTime.Now.Date.AddDays(-5), ModifiedOn=DateTime.Now.Date.AddMinutes(5), Owner=context.Users.FirstOrDefault(i=>i.Email=="ertugrul@gmail.com"), ModifiedUser="ertglr" },
                new ENTITIES.EntityClass.Task(){Text="Bu görev tamamlandı.",  CreatedOn=DateTime.Now.Date.AddDays(-10), IsComleted=true,DueDate=DateTime.Now.Date.AddDays(-5), ModifiedOn=DateTime.Now.Date.AddMinutes(5), Owner=context.Users.FirstOrDefault(i=>i.Email=="murat@gmail.com"), ModifiedUser="ertglr" },


            };
            foreach (var item in tasks)
            {
                context.Tasks.Add(item);
            }
            context.SaveChanges();

            List<History> histories = new List<History>()
            {
            new History(){ Text="asdadsasad", ModifiedUser="ertglr", CreatedOn=DateTime.Now.Date, ModifiedOn=DateTime.Now.Date.AddMinutes(5), Owner=context.Users.FirstOrDefault(i=>i.Email=="ertugrul@gmail.com")},
             new History(){Text="asdadsasaadssdadsadsadd", ModifiedUser="ertglr", CreatedOn=DateTime.Now.Date, ModifiedOn=DateTime.Now.Date.AddMinutes(5), Owner=context.Users.FirstOrDefault(i=>i.Email=="ertugrul@gmail.com")},
             new History(){ Text="asdadsasad", ModifiedUser="muratbaseren", CreatedOn=DateTime.Now.Date, ModifiedOn=DateTime.Now.Date.AddMinutes(5), Owner=context.Users.FirstOrDefault(i=>i.Email=="murat@gmail.com")},
             new History(){ Text="asdadsasasdsaddsadsaasdad", ModifiedUser="muratbaseren", CreatedOn=DateTime.Now.Date, ModifiedOn=DateTime.Now.Date.AddMinutes(5), Owner=context.Users.FirstOrDefault(i=>i.Email=="murat@gmail.com")},new History(){ Text="asdadsasad", ModifiedUser="muratbaseren", CreatedOn=DateTime.Now.Date, ModifiedOn=DateTime.Now.Date.AddMinutes(5), Owner=context.Users.FirstOrDefault(i=>i.Email=="murat@gmail.com")},
            };

            foreach (var item in histories)
            {
                context.Histories.Add(item);
            }
            context.SaveChanges();




            base.Seed(context);
        }
    }
}
