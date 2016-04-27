using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementApp.DBGateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class TeacherManager
    {
        TeacherGateway aTeacherGateway = new TeacherGateway();
        public List<Designation> GetAllDesignations()
        {
            return aTeacherGateway.GetAllDesignations();
        }

        public ActionResponse Save(Teacher aTeacher)
        {
            ActionResponse response = new ActionResponse();
            try
            {
                bool isEmailExists = aTeacherGateway.IsEmailExists(aTeacher.TeacherEmail);
                if (isEmailExists)
                {
                    response.Class = "danger";
                    response.Message = "Email [" + aTeacher.TeacherEmail + "] is already exists.";
                    return response;
                }

                aTeacherGateway.Save(aTeacher);
                response.Class = "success";
                response.Message = "Teacher Saved Successfully";
            }
            catch (SqlException ex)
            {
                response.Class = "warning";
                response.Message = ex.Message;
            }
            return response;
        }

        public List<Teacher> GetTeachersByDepartment(int departmentId)
        {
            return aTeacherGateway.GetTeachersByDepartment(departmentId);
        }

        public decimal GetCreditUsedByTeacherId(int teacherId)
        {
            return aTeacherGateway.GetCreditUsedByTeacherId(teacherId);
        }

        public ActionResponse AssignCourse(CourseAssign courseAssign)
        {
            ActionResponse response = new ActionResponse();
            try
            {
                bool isAlreadyAssigned = aTeacherGateway.IsAlreadyAssigned(courseAssign);
                if (isAlreadyAssigned)
                {
                    response.Class = "danger";
                    response.Message = "This course is already assigned to another teacher.";
                    return response;
                }

                aTeacherGateway.AssignCourse(courseAssign);
                response.Class = "success";
                response.Message = "Course Assigned successfully.";
            }
            catch (SqlException ex)
            {
                response.Class = "warning";
                response.Message = ex.Message;
            }
            return response;
        }
    }
}