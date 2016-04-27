using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementApp.DBGateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class CourseManager
    {
        CourseGateway aCourseGateway = new CourseGateway();
        public ActionResponse Save(Course aCourse)
        {
            ActionResponse response = new ActionResponse();
            try
            {
                bool isCourseCodeExists = aCourseGateway.IsCourseCodeExists(aCourse.CourseCode);
                if (isCourseCodeExists)
                {
                    response.Class = "danger";
                    response.Message = "Course Code [" + aCourse.CourseCode + "] is already exists.";
                    return response;
                }

                bool isCourseNameExists = aCourseGateway.IsCourseNameExists(aCourse.CourseName);
                if (isCourseNameExists)
                {
                    response.Class = "danger";
                    response.Message = "Course Name [" + aCourse.CourseName + "] is already exists.";
                    return response;
                }

                aCourseGateway.Save(aCourse);
                response.Class = "success";
                response.Message = "Course Saved Successfully";
            }
            catch (SqlException ex)
            {
                response.Class = "warning";
                response.Message = ex.Message;
            }
            return response;
        }

        public List<CourseSelectView> GetAvailableCoursesForStudent(int studentId, int departmentId)
        {
            return aCourseGateway.GetAvailableCoursesForStudent(studentId, departmentId);
        }

        public List<CourseSelectView> GetAvailableCoursesForTeachers(int departmentId)
        {
            return aCourseGateway.GetAvailableCoursesForTeachers(departmentId);
        }

        public List<CourseSelectView> GetCoursesByDepartment(int departmentId)
        {
            return aCourseGateway.GetCoursesByDepartment(departmentId);
        }

        public List<CourseStaticsView> GetCourseStaticsByDepartment(int departmentId)
        {
            return aCourseGateway.GetCourseStaticsByDepartment(departmentId);
        }

        public List<CourseSelectView> GetEnrolledCourses(int studentId)
        {
            return aCourseGateway.GetEnrolledCourses(studentId);
        }

        public List<CourseSelectView> GetAvailableEnrolledCourses(int studentId)
        {
            return aCourseGateway.GetAvailableEnrolledCourses(studentId);
        }
    }
}