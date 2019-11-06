using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoApp.DAL.Context;
using TodoAppApi.Models;
using TodoApp.ENTITIES.EntityClass;

namespace TodoAppApi.Controllers
{
    public class TaskController : ApiController
    {
        TodoContext db = new TodoContext();

        public IHttpActionResult GetTasks()
        {
            try
            {
                List<TaskVM> taskVM = new List<TaskVM>();
                var tasks = db.Tasks.ToList();
                foreach (var item in tasks)
                {
                    taskVM.Add(new TaskVM() { ID = item.ID, Text = item.Text, IsComplated = item.IsComleted });
                }
                if (taskVM!=null)
                {
                    return Json(taskVM.ToList());
                }
                return NotFound();

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IHttpActionResult GetTaskById(Guid id)
        {
            try
            {
                TaskVM vm = new TaskVM();
                var task = db.Tasks.FirstOrDefault(i => i.ID == id);
                vm.ID = task.ID;
                vm.Text = task.Text;
                vm.IsComplated = task.IsComleted;
                return Json(vm);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IHttpActionResult PostTask(TaskVM taskVM)
        {
            try
            {
                Task task = new Task();
                task.Text = taskVM.Text;
                task.IsComleted = taskVM.IsComplated;
                task.ModifiedUser = taskVM.ModifiedUser;
                db.Tasks.Add(task);

                if (db.SaveChanges()>0)
                {
                    return GetTasks();
                }
                return BadRequest();
                
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public IHttpActionResult PutTask(TaskVM task)
        {
            try
            {
                var updatedTask = db.Tasks.FirstOrDefault(i => i.ID == task.ID);
                db.Entry(updatedTask).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    return GetTaskById(task.ID);
                }
                return BadRequest();
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        public IHttpActionResult DeleteTask(Guid id)
        {
            try
            {
                var deletedTask = db.Tasks.Find(id);
                if (deletedTask!=null)
                {
                    db.Tasks.Remove(deletedTask);
                    if (db.SaveChanges()>0)
                    {
                        return GetTasks();
                    }
                    return BadRequest();
                }
                return BadRequest();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
