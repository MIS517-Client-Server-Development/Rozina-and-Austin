using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();

        [HttpPost]
        public ActionResult Save(Department aDepartment)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.response = aDepartmentManager.Save(aDepartment);
            return View();
        }

        [HttpGet]
        public ActionResult Save()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public ActionResult All()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }
	}
}