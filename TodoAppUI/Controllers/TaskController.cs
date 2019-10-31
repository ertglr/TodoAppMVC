using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApp.DAL.Context;
using TodoApp.ENTITIES.EntityClass;
using TodoAppUI.Filters;

namespace TodoAppUI.Controllers
{
    [AuthFilter]
    public class TaskController : Controller
    {
        TodoContext db = new TodoContext();

        [HttpGet]
        public PartialViewResult NewTask()
        {
            System.Threading.Thread.Sleep(1500);
            return PartialView("_PostingTaskPartialView", new Task());
        }
        [HttpPost] //todo:ajax.beginformdan gelecek veri için düzenleme yapılacak..
        public ActionResult NewTask(Task task)
        {
            try
            {

                var owner = Session["user"] as User;
                task.CreatedOn = DateTime.Now.Date;
                task.Owner = db.Users.FirstOrDefault(i => i.ID == (Guid)owner.ID);
                task.ModifiedUser = task.Owner.ModifiedUser;
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

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            try
            {
                var user = Session["user"] as User;
                task.Owner = db.Users.FirstOrDefault(i => i.ID == (Guid)user.ID);
                task.ModifiedUser = task.Owner.ModifiedUser;
                if (task.IsComleted)
                {
                    task.DueDate = DateTime.Now;
                }

                db.Entry(task).State = System.Data.Entity.EntityState.Modified;

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