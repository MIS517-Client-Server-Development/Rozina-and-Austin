/******************************************
 * Author: Austin Vern Songer & Rozina
 * Date:
 * Time:
 =========================================|
 * DESCRIPTION OF FILE:
 *
 *
 *
 *
 ******************************************
 */
using System.Web.Mvc;
using UniversityManagementApp.Manager;

namespace UniversityManagementApp.Controllers
{
    public class ResetController : Controller
    {
        ResetManager aResetManager = new ResetManager();
        public ActionResult Courses()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Courses(string Unassign)
        {
            if (Unassign != "")
            {
                ViewBag.response = aResetManager.UnassignCourses();
            }
            return View();
        }

        public ActionResult Classrooms()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Classrooms(string Unassign)
        {
            if (Unassign != "")
            {
                ViewBag.response = aResetManager.UnallocateClassrooms();
            }
            return View();
        }
	}
}