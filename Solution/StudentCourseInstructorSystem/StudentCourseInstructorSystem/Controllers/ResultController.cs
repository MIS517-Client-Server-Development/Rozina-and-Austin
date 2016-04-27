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
    public class ResultController : Controller
    {
        StudentManager aStudentManager = new StudentManager();
        GradeManager aGradeManager = new GradeManager();
        ResultManager aResultManager = new ResultManager();
        public ActionResult Save()
        {
            ViewBag.Students = aStudentManager.GetStudentSelectView();
            ViewBag.Grades = aGradeManager.GetAllGrades();
            return View();
        }

        [HttpPost]
        public ActionResult Save(StudentResult aStudentResult)
        {
            ViewBag.response = aResultManager.Save(aStudentResult);
            ViewBag.Students = aStudentManager.GetStudentSelectView();
            ViewBag.Grades = aGradeManager.GetAllGrades();
            return View();
        }

        public ActionResult ViewResult()
        {
            ViewBag.Students = aStudentManager.GetStudentSelectView();
            return View();
        }

        [HttpPost]
        public ActionResult Get(int StudentId)
        {
            ViewBag.resultViews = aResultManager.GetResultViewByStudent(StudentId);
            return View();
        }

        public ActionResult GeneratePDF(int studentId)
        {
            return new Rotativa.ActionAsPdf("ResultSheet", new { studentId = studentId })
            {
                FileName = "result-" + studentId + ".pdf",
            };
        }

        public ActionResult ResultSheet(int studentId)
        {
            ViewBag.Student = aStudentManager.GetStudentInfoById(studentId);
            ViewBag.resultViews = aResultManager.GetResultViewByStudent(studentId);
            return View();
        }
	}
}