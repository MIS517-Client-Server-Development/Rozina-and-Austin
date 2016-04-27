using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class ClassroomController : Controller
    {
        ClassroomManager aClassroomManager = new ClassroomManager();
        DayManager aDayManager = new DayManager();
        RoomManager aRoomManager = new RoomManager();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        public ActionResult Allocate()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login","Account");
            }

            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Days = aDayManager.GetAllDays();
            ViewBag.Rooms = aRoomManager.GetAllRooms();
            return View();
        }

        [HttpPost]
        public ActionResult Allocate(RoomAllocation aRoomAllocation)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.response = aClassroomManager.Allocate(aRoomAllocation);
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Days = aDayManager.GetAllDays();
            ViewBag.Rooms = aRoomManager.GetAllRooms();
            return View();
        }

        public ActionResult AllocationView()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult AllocationInformation(int departmentId)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.AllocationInformation = aClassroomManager.GetAllocationInformationByDepartment(departmentId);
            return View();
        }
	}
}