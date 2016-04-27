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
using System.Collections.Generic;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class CourseController : Controller
    {
        CourseManager aCourseManager = new CourseManager();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        SemesterManager aSemesterManager = new SemesterManager();
        public ActionResult Save()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Semesters = aSemesterManager.GetAllSemesters();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Course aCourse)
        {
            ViewBag.response = aCourseManager.Save(aCourse);
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Semesters = aSemesterManager.GetAllSemesters();
            return View();
        }

        public ActionResult Statics()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult StaticsView(int DepartmentId)
        {
            ViewBag.courseStatics = aCourseManager.GetCourseStaticsByDepartment(DepartmentId);
            return View();
        }
	}
}