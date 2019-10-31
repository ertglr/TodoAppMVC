using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApp.DAL.Context;
using TodoApp.ENTITIES.EntityClass;
using TodoAppUI.Filters;
using TodoAppUI.Models;

namespace TodoAppUI.Controllers
{

    public class UserController : Controller
    {
        TodoContext db = new TodoContext();
        // GET: User

        public ActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(UserVM user)
        {
            try
            {
                var userLogin = db.Users.FirstOrDefault(i => i.Email == user.Email && i.Password == user.Password);

                if (userLogin == null)
                {
                    return View(userLogin);
                }

               

                if (ModelState.IsValid)
                {
                   
                        
                 
                        Session.Add("user", userLogin);

                        return RedirectToAction("Index");
                    

                }
                else
                {
                    var errors = ModelState.Values.Select(i => i.Errors).ToList();
                    return View(user);
                }
               

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
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    if (db.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View(user);
                    }
                }

                else return View();
               
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

                var tasks = db.Tasks.Where(i => i.Owner.ID == (Guid)user.ID).ToList();
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

                var owner = Session["user"] as User;
                task.Owner = db.Users.FirstOrDefault(i => i.ID == (Guid)owner.ID);
                task.ModifiedUser = task.Owner.ModifiedUser;
                db.Tasks.Add(task);
                if (db.SaveChanges()>0)
                {
                    return PartialView("_NewTaskPartialView");
                }
                
                

                return PartialView(task);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }




    }
}