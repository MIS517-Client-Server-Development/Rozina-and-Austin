using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DBGateway
{
    public class DayGateway : Gateway
    {
        public List<Day> GetAllDays()
        {
            string query = "SELECT * FROM Days ORDER BY DayId ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                List<Day> days = new List<Day>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Day aDay = new Day
                    {
                        DayId = Convert.ToInt32(reader["DayId"].ToString()),
                        DayName = reader["DayName"].ToString()
                    };
                    days.Add(aDay);
                }
                return days;
            }
        }
    }
}