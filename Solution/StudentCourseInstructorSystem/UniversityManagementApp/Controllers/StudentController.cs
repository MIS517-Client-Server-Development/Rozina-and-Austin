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
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.departments = aDepartmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Student aStudent)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ActionResponse response = aStudentManager.Save(aStudent);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Enroll()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Students = aStudentManager.GetStudentSelectView();
            return View();
        }

        [HttpPost]
        public ActionResult Enroll(Enrollment aEnrollment)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.response = aStudentManager.Enroll(aEnrollment);
            ViewBag.Students = aStudentManager.GetStudentSelectView();
            return View();
        }

        [HttpPost]
        public ActionResult Get(int StudentId)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            StudentView aStudentView = aStudentManager.GetStudentViewById(StudentId);
            return Json(aStudentView, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AvailableCourses(int StudentId, int DepartmentId)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            List<CourseSelectView> CourseSelectViews = aCourseManager.GetAvailableCoursesForStudent(StudentId, DepartmentId);
            return Json(CourseSelectViews, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DepartmentCourses(int DepartmentId)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            List<CourseSelectView> CourseSelectViews = aCourseManager.GetCoursesByDepartment(DepartmentId);
            return Json(CourseSelectViews, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EnrolledCourses(int StudentId)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            List<CourseSelectView> CourseSelectViews = aCourseManager.GetEnrolledCourses(StudentId);
            return Json(CourseSelectViews, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AvailableEnrolledCourses(int StudentId)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            List<CourseSelectView> CourseSelectViews = aCourseManager.GetAvailableEnrolledCourses(StudentId);
            return Json(CourseSelectViews, JsonRequestBehavior.AllowGet);
        }
	}
}