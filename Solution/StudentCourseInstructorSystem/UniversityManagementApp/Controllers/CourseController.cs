﻿using System.Collections.Generic;
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
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Semesters = aSemesterManager.GetAllSemesters();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Course aCourse)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.response = aCourseManager.Save(aCourse);
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Semesters = aSemesterManager.GetAllSemesters();
            return View();
        }

        public ActionResult Statics()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult StaticsView(int DepartmentId)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.courseStatics = aCourseManager.GetCourseStaticsByDepartment(DepartmentId);
            return View();
        }
	}
}