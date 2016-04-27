using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DBGateway
{
    public class ResultGateway : Gateway
    {
        public bool IsAlreadySaved(StudentResult aStudentResult)
        {
            string query = "SELECT * FROM StudentResults WHERE StudentId =@stdId AND CourseId =@courseId AND IsCurrent =1";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("stdId", sqlDbType: SqlDbType.Int);
                command.Parameters["stdId"].Value = aStudentResult.StudentId;

                command.Parameters.Add("courseId", sqlDbType: SqlDbType.Int);
                command.Parameters["courseId"].Value = aStudentResult.CourseId;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public void Save(StudentResult aStudentResult)
        {
            string query = "INSERT INTO StudentResults (StudentId, CourseId, GradeId, IsCurrent) VALUES (@stdId, @courseId, @gradeId, @isCurrent)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("stdId", sqlDbType: SqlDbType.Int);
                command.Parameters["stdId"].Value = aStudentResult.StudentId;

                command.Parameters.Add("courseId", sqlDbType: SqlDbType.Int);
                command.Parameters["courseId"].Value = aStudentResult.CourseId;

                command.Parameters.Add("gradeId", sqlDbType: SqlDbType.Int);
                command.Parameters["gradeId"].Value = aStudentResult.GradeId;

                command.Parameters.Add("isCurrent", sqlDbType: SqlDbType.Bit);
                command.Parameters["isCurrent"].Value = aStudentResult.IsCurrent;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<ResultView> GetResultViewByStudent(int studentId)
        {
            string query = "SELECT C.CourseCode, C.CourseName, G.GradeLetter FROM Enrollments E LEFT JOIN Courses C ON E.CourseId = C.CourseId LEFT JOIN StudentResults R ON ( E.StudentId = R.StudentId AND E.CourseId = R.CourseId AND E.IsCurrent = R.IsCurrent ) LEFT JOIN Grades G ON R.GradeId = G.GradeId WHERE E.StudentId =@studentId AND E.IsCurrent =1 ORDER BY C.CourseCode ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("studentId", sqlDbType: SqlDbType.Int);
                command.Parameters["studentId"].Value = studentId;

                List<ResultView> resultViews = new List<ResultView>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ResultView aResultView = new ResultView
                    {
                        CourseCode = reader["CourseCode"].ToString(),
                        CourseName = reader["CourseName"].ToString(),
                        GradeLetter = reader["GradeLetter"].ToString()
                    };
                    resultViews.Add(aResultView);
                }
                return resultViews;
            }
        }
    }
}