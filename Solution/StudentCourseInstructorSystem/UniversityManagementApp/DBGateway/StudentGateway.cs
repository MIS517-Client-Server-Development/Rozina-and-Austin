using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DBGateway
{
    public class StudentGateway : Gateway
    {
        public bool IsEmailExists(string studentEmail)
        {
            string query = "SELECT * FROM Students WHERE StudentEmail =@email";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("email", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["email"].Value = studentEmail;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public int GetMaxStudentId()
        {
            string query = "SELECT ISNULL(MAX(StudentId), 0) AS MaxID FROM Students";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                int stdId = 0;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    stdId = Convert.ToInt32(reader["MaxID"].ToString());
                }
                return (stdId + 1);
            }
        }

        public int GetRegSl(int departmentId, int year)
        {
            string query = "SELECT COUNT(StudentId) AS TotalRows FROM Students WHERE DepartmentId=@deptId AND YEAR(RegDate)=@year";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("deptId", sqlDbType: SqlDbType.Int);
                command.Parameters["deptId"].Value = departmentId;

                command.Parameters.Add("year", sqlDbType: SqlDbType.Int);
                command.Parameters["year"].Value = year;

                int totalRows = 0;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    totalRows = Convert.ToInt32(reader["TotalRows"].ToString());
                }
                return (totalRows + 1);
            }
        }

        public void Save(Student aStudent)
        {
            string query = "INSERT INTO Students (RegNo, StudentName, StudentEmail, StudentContactNo, StudentAddress, DepartmentId, RegDate) VALUES (@regNo, @name, @email, @contactNo, @address, @deptId, @regDate)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("regNo", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["regNo"].Value = aStudent.RegNo;

                command.Parameters.Add("name", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["name"].Value = aStudent.StudentName;

                command.Parameters.Add("email", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["email"].Value = aStudent.StudentEmail;

                command.Parameters.Add("contactNo", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["contactNo"].Value = aStudent.StudentContactNo;

                command.Parameters.Add("address", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["address"].Value = aStudent.StudentAddress;

                command.Parameters.Add("deptId", sqlDbType: SqlDbType.Int);
                command.Parameters["deptId"].Value = aStudent.DepartmentId;

                command.Parameters.Add("regDate", sqlDbType: SqlDbType.Date);
                command.Parameters["regDate"].Value = aStudent.RegDate.Date;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<StudentSelectView> GetStudentSelectView()
        {
            string query = "SELECT StudentId, RegNo FROM Students ORDER BY RegNo ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                List<StudentSelectView> studentViews = new List<StudentSelectView>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StudentSelectView aView = new StudentSelectView
                    {
                        StudentId = Convert.ToInt32(reader["StudentId"].ToString()),
                        RegNo = reader["RegNo"].ToString()
                    };
                    studentViews.Add(aView);
                }
                return studentViews;
            }
        }

        public StudentView GetStudentViewById(int studentId)
        {
            string query = "SELECT S.StudentName, S.StudentEmail, S.DepartmentId, D.DepartmentName FROM Students S LEFT JOIN Departments D ON S.DepartmentId = D.DepartmentId WHERE S.StudentId =@id";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("id", sqlDbType: SqlDbType.Int);
                command.Parameters["id"].Value = studentId;

                StudentView aStudentView = new StudentView();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    aStudentView.StudentName = reader["StudentName"].ToString();
                    aStudentView.StudentEmail = reader["StudentEmail"].ToString();
                    aStudentView.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
                    aStudentView.DepartmentName = reader["DepartmentName"].ToString();
                }
                return aStudentView;
            }
        }

        public bool IsAlreadyEnrolled(Enrollment aEnrollment)
        {
            string query = "SELECT * FROM Enrollments WHERE StudentId =@stdId AND CourseId =@courseId AND IsCurrent =1";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("stdId", sqlDbType: SqlDbType.Int);
                command.Parameters["stdId"].Value = aEnrollment.StudentId;

                command.Parameters.Add("courseId", sqlDbType: SqlDbType.Int);
                command.Parameters["courseId"].Value = aEnrollment.CourseId;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public void Enroll(Enrollment aEnrollment)
        {
            string query = "INSERT INTO Enrollments (StudentId, CourseId, EnrollmentDate, IsCurrent) VALUES (@stdId, @courseId, @enrollmentDate, @isCurrent)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("stdId", sqlDbType: SqlDbType.Int);
                command.Parameters["stdId"].Value = aEnrollment.StudentId;

                command.Parameters.Add("courseId", sqlDbType: SqlDbType.Int);
                command.Parameters["courseId"].Value = aEnrollment.CourseId;

                command.Parameters.Add("enrollmentDate", sqlDbType: SqlDbType.Date);
                command.Parameters["enrollmentDate"].Value = aEnrollment.EnrollmentDate.Date;

                command.Parameters.Add("isCurrent", sqlDbType: SqlDbType.Bit);
                command.Parameters["isCurrent"].Value = aEnrollment.IsCurrent;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public StudentDetailView GetStudentInfoById(int studentId)
        {
            string query = "SELECT S.RegNo, S.StudentName, S.StudentEmail, S.StudentContactNo, S.StudentAddress, S.RegDate, D.DepartmentCode, D.DepartmentName FROM Students S LEFT JOIN Departments D ON S.DepartmentId = D.DepartmentId WHERE S.StudentId =@id";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("id", sqlDbType: SqlDbType.Int);
                command.Parameters["id"].Value = studentId;

                StudentDetailView student = new StudentDetailView();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    student.RegNo = reader["RegNo"].ToString();
                    student.StudentName = reader["StudentName"].ToString();
                    student.StudentEmail = reader["StudentEmail"].ToString();
                    student.StudentContactNo = reader["StudentContactNo"].ToString();
                    student.StudentAddress = reader["StudentAddress"].ToString();
                    student.RegDate = Convert.ToDateTime(reader["RegDate"].ToString());
                    student.DepartmentCode = reader["DepartmentCode"].ToString();
                    student.DepartmentName = reader["DepartmentName"].ToString();
                }
                return student;
            }
        }
    }
}