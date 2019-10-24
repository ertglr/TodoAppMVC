using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApp.DAL.Context;
using TodoApp.ENTITIES.EntityClass;

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
                    Session.Add("user", user.ID);

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

        public ActionResult Index()
        {
            try
            {
                var user = Session["user"];
                
                var tasks = db.Tasks.Where(i => i.Owner.ID==(Guid)user).ToList();
                return View(tasks);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }



        //public ActionResult Register()
        //{

        //}


    }
}