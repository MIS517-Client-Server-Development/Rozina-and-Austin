using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DBGateway
{
    public class SemesterGateway : Gateway
    {
        public List<Semester> GetAllSemesters()
        {
            string query = "SELECT * FROM Semesters ORDER BY SemesterId ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                List<Semester> semesters = new List<Semester>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Semester aSemester = new Semester
                    {
                        SemesterId = Convert.ToInt32(reader["SemesterId"].ToString()),
                        SemesterName = reader["SemesterName"].ToString()
                    };
                    semesters.Add(aSemester);

                }
                return semesters;
            }
        }
    }
}