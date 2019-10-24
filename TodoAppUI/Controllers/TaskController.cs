using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApp.DAL.Context;
using TodoApp.ENTITIES.EntityClass;

namespace TodoAppUI.Controllers
{
    public class TaskController : Controller
    {
        TodoContext db = new TodoContext();

        [HttpGet]
        public ActionResult NewTask()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewTask(Task task)
        {
            try
            {
                var owner = db.Users.FirstOrDefault(i => i.ModifiedUser == task.ModifiedUser);
                task.CreatedOn = DateTime.Now.Date;
                task.IsComleted = false;
                task.Owner = owner;
                db.Tasks.Add(task);
                if (db.SaveChanges()>0)
                {
                    return RedirectToAction("Index", "User",task);
                }
                else
                {
                    return View(task);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
           
        }



        public ActionResult Edit(Guid id)
        {
            try
            {
                var task = db.Tasks.Find(id);
                return View(task);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }

        [HttpPost] //modified User'ı username olarak alıyor
        public ActionResult Edit(Task task)
        {
            try
            {
                var user = db.Users.FirstOrDefault(i => i.Username == task.Owner.Username);
                task.Owner = user;
                    db.Entry(task).State = System.Data.Entity.EntityState.Modified;
                    return RedirectToAction("Index", "User", task);
                
               
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
                
            }
        }


    }
}