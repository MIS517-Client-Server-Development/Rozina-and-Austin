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
    public class StudentController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        CourseManager aCourseManager = new CourseManager();
        StudentManager aStudentManager = new StudentManager();
        public ActionResult Register()
        {
            ViewBag.departments = aDepartmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public JsonResult Save(Student aStudent)
        {
            ActionResponse response = aStudentManager.Save(aStudent);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Enroll()
        {
            ViewBag.Students = aStudentManager.GetStudentSelectView();
            return View();
        }

        [HttpPost]
        public ActionResult Enroll(Enrollment aEnrollment)
        {
            ViewBag.response = aStudentManager.Enroll(aEnrollment);
            ViewBag.Students = aStudentManager.GetStudentSelectView();
            return View();
        }

        [HttpPost]
        public JsonResult Get(int StudentId)
        {
            StudentView aStudentView = aStudentManager.GetStudentViewById(StudentId);
            return Json(aStudentView, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AvailableCourses(int StudentId, int DepartmentId)
        {
            List<CourseSelectView> CourseSelectViews = aCourseManager.GetAvailableCoursesForStudent(StudentId, DepartmentId);
            return Json(CourseSelectViews, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DepartmentCourses(int DepartmentId)
        {
            List<CourseSelectView> CourseSelectViews = aCourseManager.GetCoursesByDepartment(DepartmentId);
            return Json(CourseSelectViews, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EnrolledCourses(int StudentId)
        {
            List<CourseSelectView> CourseSelectViews = aCourseManager.GetEnrolledCourses(StudentId);
            return Json(CourseSelectViews, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AvailableEnrolledCourses(int StudentId)
        {
            List<CourseSelectView> CourseSelectViews = aCourseManager.GetAvailableEnrolledCourses(StudentId);
            return Json(CourseSelectViews, JsonRequestBehavior.AllowGet);
        }
	}
}