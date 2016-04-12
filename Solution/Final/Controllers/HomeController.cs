using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Text;

namespace Final.Controllers
{
    public class HomeController : Controller
    {  //
        // GET: /Home/

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Portfolio()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Enroll()
        {
            var programs = new List<Final.Models.ProgramModel>();
            var majors = new List<Final.Models.MajorModel>();

            try
            {
                Bootstrapper.InitializeDB();
            }
            catch
            {
                return RedirectToAction("ConfigError");
            }

            //TO DO: pass list to program and majors from data layer
            ViewBag.Programs = new ManagerFactory().GetProgramManager().GetAll().AsEnumerable();
            ViewBag.Majors = new ManagerFactory().GetMajorManager().GetAll().AsEnumerable();

            return View();
        }


        public ActionResult ConfigError()
        {
            return View();
        }

        public ActionResult UnderConstruction()
        {

            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        public ActionResult SendPassword(Final.Models.LogOnModel logon)
        {
            try
            {
                //SEND EMAIL TO STUDENT
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("tony.nash1890@gmail.com", "killerbeewert");

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("online-grading@ymail.com");
                    mail.To.Add(logon.UserName);
                    mail.Subject = "Thank you for choosing us";

                    StringBuilder bodyhtml = new StringBuilder();
                    bodyhtml.AppendLine("Online Grading Credential");
                    bodyhtml.AppendLine("Username:" + logon.UserName);
                    bodyhtml.AppendLine("Password:" + new ManagerFactory().GetAccountManager().GetById(logon.UserName).Password);

                    mail.Body = bodyhtml.ToString();

                    smtp.Send(mail);
                }
            }
            catch { }

            return View();
        }
    }
}
