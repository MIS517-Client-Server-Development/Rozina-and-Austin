using System.Web.Mvc;
using UniversityManagementApp.Manager;

namespace UniversityManagementApp.Controllers
{
    public class ResetController : Controller
    {
        ResetManager aResetManager = new ResetManager();
        public ActionResult Courses()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Courses(string Unassign)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (Unassign != "")
            {
                ViewBag.response = aResetManager.UnassignCourses();
            }
            return View();
        }

        public ActionResult Classrooms()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Classrooms(string Unassign)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (Unassign != "")
            {
                ViewBag.response = aResetManager.UnallocateClassrooms();
            }
            return View();
        }
	}
}