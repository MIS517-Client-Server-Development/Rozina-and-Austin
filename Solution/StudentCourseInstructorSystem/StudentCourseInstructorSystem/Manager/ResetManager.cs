using System.Data.SqlClient;
using UniversityManagementApp.DBGateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class ResetManager
    {
        ResetGateway aResetGateway = new ResetGateway();
        public ActionResponse UnassignCourses()
        {
            ActionResponse response = new ActionResponse();
            try
            {
                aResetGateway.Reset("CourseAssign");
                aResetGateway.Reset("Enrollments");
                aResetGateway.Reset("StudentResults");
                response.Class = "success";
                response.Message = "All Courses has been UnassignED successfully.";
            }
            catch (SqlException ex)
            {
                response.Class = "danger";
                response.Message = ex.Message;
            }
            return response;
        }

        public ActionResponse UnallocateClassrooms()
        {
            ActionResponse response = new ActionResponse();
            try
            {
                aResetGateway.Reset("RoomAllocation");
                response.Class = "success";
                response.Message = "Room allocation information has been reseted successfully.";
            }
            catch (SqlException ex)
            {
                response.Class = "danger";
                response.Message = ex.Message;
            }
            return response;
        }
    }
}