using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("WelcomeView");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(User u)
        {
            TestDatabaseEntities1 db = new TestDatabaseEntities1();

            User us = new Models.User();
            us.Password = u.Password;
            us.Username = u.Username;

            db.Users.Add(us);
            db.SaveChanges();



            return View("Index");
        }

        public ActionResult AfterSplit()
        {
            return View("StartPage");
        }
    }
}