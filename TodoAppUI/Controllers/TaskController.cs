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

                var owner = Session["user"];
                task.CreatedOn = DateTime.Now.Date;
                task.Owner = db.Users.FirstOrDefault(i => i.ID == (Guid)owner);
                //task.ID = Guid.NewGuid();
                db.Tasks.Add(task);
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("Index", "User");
                }

                return View(task);

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
                var user = Session["user"];
                var newTask = new Task();
                newTask.ID = task.ID;
                newTask.IsComleted = task.IsComleted;
                newTask.ModifiedOn = DateTime.Now;
                newTask.Owner = db.Users.FirstOrDefault(i => i.ID == (Guid)user);
                newTask.Text = task.Text;
                newTask.CreatedOn = task.CreatedOn;
                newTask.ModifiedUser = task.ModifiedUser;
                if (newTask.IsComleted)
                {
                    newTask.DueDate = DateTime.Now;
                }

                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("Index", "User");

                }

                return View(task);

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();

            }
        }

        public ActionResult Delete(Guid ID)
        {
            try
            {
                var task = db.Tasks.Find(ID);
                db.Tasks.Remove(task);
                db.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


    }
}