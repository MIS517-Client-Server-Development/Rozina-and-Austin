using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DBGateway
{
    public class ClassroomGateway : Gateway
    {
        public void Allocate(RoomAllocation aRoomAllocation)
        {
            string query = "INSERT INTO RoomAllocation (RoomId, CourseId, DayId, StartTime, EndTime, IsCurrent) VALUES (@roomId, @courseId, @dayId, @startTime, @endTime, @isCurrent)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("roomId", sqlDbType: SqlDbType.Int);
                command.Parameters["roomId"].Value = aRoomAllocation.RoomId;

                command.Parameters.Add("courseId", sqlDbType: SqlDbType.Int);
                command.Parameters["courseId"].Value = aRoomAllocation.CourseId;

                command.Parameters.Add("dayId", sqlDbType: SqlDbType.Int);
                command.Parameters["dayId"].Value = aRoomAllocation.DayId;

                command.Parameters.Add("startTime", sqlDbType: SqlDbType.Time);
                command.Parameters["startTime"].Value = aRoomAllocation.StartTime.TimeOfDay;

                command.Parameters.Add("endTime", sqlDbType: SqlDbType.Time);
                command.Parameters["endTime"].Value = aRoomAllocation.EndTime.TimeOfDay;

                command.Parameters.Add("isCurrent", sqlDbType: SqlDbType.Bit);
                command.Parameters["isCurrent"].Value = aRoomAllocation.IsCurrent;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool IsOverlap(RoomAllocation aRoomAllocation)
        {
            string query = "SELECT * FROM RoomAllocation WHERE RoomId=@roomId AND DayId=@dayId AND ( ( StartTime > @startTime AND StartTime < @endTime ) OR ( EndTime > @startTime AND EndTime < @endTime ) ) AND IsCurrent=1";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("roomId", sqlDbType: SqlDbType.Int);
                command.Parameters["roomId"].Value = aRoomAllocation.RoomId;

                command.Parameters.Add("dayId", sqlDbType: SqlDbType.Int);
                command.Parameters["dayId"].Value = aRoomAllocation.DayId;

                command.Parameters.Add("startTime", sqlDbType: SqlDbType.Time);
                command.Parameters["startTime"].Value = aRoomAllocation.StartTime.TimeOfDay;

                command.Parameters.Add("endTime", sqlDbType: SqlDbType.Time);
                command.Parameters["endTime"].Value = aRoomAllocation.EndTime.TimeOfDay;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public List<RoomAllocationView> GetAllocationInformationByDepartment(int departmentId)
        {
            string query = "SELECT C.CourseCode, C.CourseName, FORMAT(CAST(A.StartTime AS DATETIME),'h:mm tt')  AS StartTime, FORMAT(CAST(A.EndTime AS DATETIME),'h:mm tt') AS EndTime, R.RoomNo, D.[DayName] FROM Courses C LEFT JOIN RoomAllocation A ON ( C.CourseId = A.CourseId	AND A.IsCurrent=1 ) LEFT JOIN Rooms R ON A.RoomId = R.RoomId LEFT JOIN [Days] D ON A.DayId = D.DayId WHERE C.DepartmentId=@deptId ORDER BY C.CourseCode ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("deptId", sqlDbType: SqlDbType.Int);
                command.Parameters["deptId"].Value = departmentId;

                List<RoomAllocationView> roomAllocationViews = new List<RoomAllocationView>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    RoomAllocationView aAllocationView = new RoomAllocationView
                    {
                        CourseCode = reader["CourseCode"].ToString(),
                        CourseName = reader["CourseName"].ToString(),
                        RoomNo = reader["RoomNo"].ToString(),
                        DayName = reader["DayName"].ToString(),
                        StartTime = reader["StartTime"].ToString(),
                        EndTime = reader["EndTime"].ToString()
                    };
                    roomAllocationViews.Add(aAllocationView);
                }
                return roomAllocationViews;
            }
        }
    }
}