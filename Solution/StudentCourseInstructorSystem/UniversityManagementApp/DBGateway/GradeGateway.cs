using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DBGateway
{
    public class GradeGateway : Gateway
    {
        public List<Grade> GetAllGrades()
        {
            string query = "SELECT * FROM Grades ORDER BY GradeId ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                List<Grade> grades = new List<Grade>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Grade aGrade = new Grade
                    {
                        GradeId = Convert.ToInt32(reader["GradeId"].ToString()),
                        GradeLetter = reader["GradeLetter"].ToString()
                    };
                    grades.Add(aGrade);

                }
                return grades;
            }
        }
    }
}