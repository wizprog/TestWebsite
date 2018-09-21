using System.Net;
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
            return View("AboutView");
        }

        public ActionResult AboutView()
        {
            return View("AboutView");
        }

        public ActionResult ContactUs()
        {
            return View("ContactView");
        }

        public void SendMail(MailInfo m)
        {
            var fromAddress = "sendmemailbelgrade@gmail.com";
            
            var toAddress = "mbabic96@gmail.com";
            
            const string fromPassword = "vodavoda123";


            string subject = m.subject;
            string body = "From: " + m.name + "\n";
            body += "Email: " + m.contactMail + "\n";
            body += "Subject: " + m.subject + "\n";
            body += "Question: \n" + m.question + "\n";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }

        public ActionResult HighSchool()
        {
            return View("HighSchoolView");
        }

        public ActionResult University()
        {
            return View("UniversityView");
        }

        public ActionResult PrimarySchool()
        {
            return View("PrimarySchoolView");
        }
    }
}