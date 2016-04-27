using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class ResultController : Controller
    {
        StudentManager aStudentManager = new StudentManager();
        GradeManager aGradeManager = new GradeManager();
        ResultManager aResultManager = new ResultManager();
        public ActionResult Save()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Students = aStudentManager.GetStudentSelectView();
            ViewBag.Grades = aGradeManager.GetAllGrades();
            return View();
        }

        [HttpPost]
        public ActionResult Save(StudentResult aStudentResult)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.response = aResultManager.Save(aStudentResult);
            ViewBag.Students = aStudentManager.GetStudentSelectView();
            ViewBag.Grades = aGradeManager.GetAllGrades();
            return View();
        }

        public ActionResult ViewResult()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

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

            ViewBag.resultViews = aResultManager.GetResultViewByStudent(StudentId);
            return View();
        }

        public ActionResult GeneratePDF(int studentId)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return new Rotativa.ActionAsPdf("ResultSheet", new { studentId = studentId })
            {
                FileName = "result-" + studentId + ".pdf",
            };
        }

        public ActionResult ResultSheet(int studentId)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Student = aStudentManager.GetStudentInfoById(studentId);
            ViewBag.resultViews = aResultManager.GetResultViewByStudent(studentId);
            return View();
        }
	}
}