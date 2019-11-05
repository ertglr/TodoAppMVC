using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApp.BLL;

namespace TodoAppUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Test test = new Test();
            return View();
        }


        public ActionResult Error()
        {
            if (TempData["error"] == null)
            {
                return RedirectToAction("Index");

            }

            Exception exception = TempData["error"] as Exception;
            return View(exception);
        }
    }
}