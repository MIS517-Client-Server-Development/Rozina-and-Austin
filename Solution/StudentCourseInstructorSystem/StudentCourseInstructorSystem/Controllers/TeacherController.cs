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
    public class TeacherController : Controller
    {
        TeacherManager aTeacherManager = new TeacherManager();
        CourseManager aCourseManager = new CourseManager();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        public ActionResult Save()
        {
            ViewBag.Designations = aTeacherManager.GetAllDesignations();
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Teacher aTeacher)
        {
            ViewBag.response = aTeacherManager.Save(aTeacher);
            ViewBag.Designations = aTeacherManager.GetAllDesignations();
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }

        public ActionResult AssignCourse()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult AssignCourse(CourseAssign courseAssign)
        {
            ViewBag.response = aTeacherManager.AssignCourse(courseAssign);
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public JsonResult DepartmentCourses(int DepartmentId)
        {
            List<CourseSelectView> CourseSelectViews = aCourseManager.GetCoursesByDepartment(DepartmentId);
            return Json(CourseSelectViews, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DepartmentTeachers(int DepartmentId)
        {
            List<Teacher> teachers = aTeacherManager.GetTeachersByDepartment(DepartmentId);
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public decimal CreditUsed(int TeacherId)
        {
            decimal creditUsed = aTeacherManager.GetCreditUsedByTeacherId(TeacherId);
            return creditUsed;
        }

        [HttpPost]
        public JsonResult AvailableCourses(int DepartmentId)
        {
            List<CourseSelectView> CourseSelectViews = aCourseManager.GetAvailableCoursesForTeachers(DepartmentId);
            return Json(CourseSelectViews, JsonRequestBehavior.AllowGet);
        }
	}
}