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
        public ActionResult Login(User user)
        {
            try
            {
                if (db.Users.Any(i => i.Email == user.Email && i.Password == user.Password))
                {
                    var model = db.Users.FirstOrDefault(i=>i.Email==user.Email);
                    
                    return RedirectToAction("Index",model);
                }
                else
                {
                    return View();
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

        public ActionResult Index(User user)
        {
            try
            {
                var tasks = db.Tasks.Where(i => i.Owner.ID == user.ID).ToList();
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