using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementApp.DBGateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class StudentManager
    {
        StudentGateway aStudentGateway = new StudentGateway();
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
        public ActionResponse Save(Student aStudent)
        {
            ActionResponse response = new ActionResponse();
            try
            {
                bool isEmailExists = aStudentGateway.IsEmailExists(aStudent.StudentEmail);
                if (isEmailExists)
                {
                    response.Class = "danger";
                    response.Message = "Email [" + aStudent.StudentEmail + "] is already exists.";
                    return response;
                }
                //EEE-2016-001
                string deptCode = aDepartmentGateway.GetDepartmentCodeById(aStudent.DepartmentId);
                //int stdId = aStudentGateway.GetMaxStudentId();
                //string regNo = deptCode + "-" + aStudent.RegDate.Year + "-" + stdId.ToString("D3");

                int nextId = aStudentGateway.GetRegSl(aStudent.DepartmentId, aStudent.RegDate.Year);
                string regNo = deptCode + "-" + aStudent.RegDate.Year + "-" + nextId.ToString("D3");
                aStudent.RegNo = regNo;

                aStudentGateway.Save(aStudent);
                response.Class = "success";
                response.Message = regNo;
            }
            catch (SqlException ex)
            {
                response.Class = "warning";
                response.Message = ex.Message;
            }
            return response;
        }

        public ActionResponse Enroll(Enrollment aEnrollment)
        {
            ActionResponse response = new ActionResponse();
            try
            {
                bool isAlreadyEnrolled = aStudentGateway.IsAlreadyEnrolled(aEnrollment);
                if (isAlreadyEnrolled)
                {
                    response.Class = "danger";
                    response.Message = "This student is already enrolled in this course.";
                    return response;
                }

                aStudentGateway.Enroll(aEnrollment);
                response.Class = "success";
                response.Message = "Enrollment successfully completed.";
            }
            catch (SqlException ex)
            {
                response.Class = "warning";
                response.Message = ex.Message;
            }
            return response;
        }

        public List<StudentSelectView> GetStudentSelectView()
        {
            return aStudentGateway.GetStudentSelectView();
        }

        public StudentView GetStudentViewById(int studentId)
        {
            return aStudentGateway.GetStudentViewById(studentId);
        }

        public StudentDetailView GetStudentInfoById(int studentId)
        {
            return aStudentGateway.GetStudentInfoById(studentId);
        }
    }
}