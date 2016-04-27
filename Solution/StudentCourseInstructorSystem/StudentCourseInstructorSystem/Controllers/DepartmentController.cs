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
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();

        [HttpPost]
        public ActionResult Save(Department aDepartment)
        {
            ViewBag.response = aDepartmentManager.Save(aDepartment);
            return View();
        }

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        public ActionResult All()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }
	}
}