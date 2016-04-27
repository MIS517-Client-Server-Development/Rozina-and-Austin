using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementApp.DBGateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class ClassroomManager
    {
        ClassroomGateway aClassroomGateway = new ClassroomGateway();

        public ActionResponse Allocate(RoomAllocation aRoomAllocation)
        {
            ActionResponse response = new ActionResponse();
            try
            {
                int compare = DateTime.Compare(aRoomAllocation.StartTime, aRoomAllocation.EndTime);
                if (compare > 0)
                {
                    response.Class = "danger";
                    response.Message = "End Time [" + aRoomAllocation.EndTime.ToString("hh:mm tt") + "] must be grater than Start Time [" + aRoomAllocation.StartTime.ToString("hh:mm tt") + "].";
                    return response;
                }
                bool isOverlap = aClassroomGateway.IsOverlap(aRoomAllocation);
                if (isOverlap)
                {
                    response.Class = "danger";
                    response.Message = "Overlapping problem: Another class is allocated with this schedule.";
                    return response;
                }

                aClassroomGateway.Allocate(aRoomAllocation);
                response.Class = "success";
                response.Message = "Room Allocated successfully.";
            }
            catch (SqlException ex)
            {
                response.Class = "warning";
                response.Message = ex.Message;
            }
            return response;
        }

        public List<RoomAllocationView> GetAllocationInformationByDepartment(int departmentId)
        {
            return aClassroomGateway.GetAllocationInformationByDepartment(departmentId);
        }
    }
}