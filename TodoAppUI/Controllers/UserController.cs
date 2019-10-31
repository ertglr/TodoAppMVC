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
    
    public class UserController : Controller
    {
        TodoContext db = new TodoContext();
        // GET: User

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            try
            {
                if (db.Users.Any(i => i.Email == Email && i.Password == Password))
                {
                    var user = db.Users.FirstOrDefault(i => i.Email ==Email);
                    //var task = db.Tasks.FirstOrDefault(i=>i.Owner.ID==user.ID);
                    Session.Add("user", user);

                    return RedirectToAction("Index");
                }
                
                    return View();
                
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
               
                db.Users.Add(user);
                if (db.SaveChanges()>0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(user);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }
        [AuthFilter]
        public ActionResult Index()
        {
            try
            {
                var user = Session["user"] as User;
                
                var tasks = db.Tasks.Where(i => i.Owner.ID==(Guid)user.ID).ToList();
                return View(tasks);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public PartialViewResult Index(Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var owner = Session["user"] as User;
                    task.Owner = db.Users.FirstOrDefault(i => i.ID == (Guid)owner.ID);
                    db.Tasks.Add(task);
                    db.SaveChanges();
                    return PartialView("_NewTaskPartialView");
                }
                return PartialView(task);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        //public ActionResult Deneme()
        //{
        //    return RedirectToAction()
        //}
        


    }
}