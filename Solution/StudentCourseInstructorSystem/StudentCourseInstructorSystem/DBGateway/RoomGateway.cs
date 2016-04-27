using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DBGateway
{
    public class RoomGateway : Gateway
    {
        public List<Room> GetAllRooms()
        {
            string query = "SELECT * FROM Rooms ORDER BY RoomNo ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                List<Room> rooms = new List<Room>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Room aRoom = new Room
                    {
                        RoomId = Convert.ToInt32(reader["RoomId"].ToString()),
                        RoomNo = reader["RoomNo"].ToString()
                    };
                    rooms.Add(aRoom);
                }
                return rooms;
            }
        }
    }
}