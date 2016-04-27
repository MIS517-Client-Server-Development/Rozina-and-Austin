using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DBGateway
{
    public class CourseGateway : Gateway
    {
        public bool IsCourseCodeExists(string courseCode)
        {
            string query = "SELECT * FROM Courses WHERE CourseCode =@courseCode";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("courseCode", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["courseCode"].Value = courseCode;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public bool IsCourseNameExists(string courseName)
        {
            string query = "SELECT * FROM Courses WHERE CourseName =@courseName";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("courseName", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["courseName"].Value = courseName;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public void Save(Course aCourse)
        {
            string query = "INSERT INTO Courses (CourseCode, CourseName, CourseCredit, CourseDescription, DepartmentId, SemesterId) VALUES (@code, @name, @credit, @description, @deptId, @semesterId)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("code", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["code"].Value = aCourse.CourseCode;

                command.Parameters.Add("name", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["name"].Value = aCourse.CourseName;

                command.Parameters.Add("credit", sqlDbType: SqlDbType.Decimal);
                command.Parameters["credit"].Value = aCourse.CourseCredit;

                command.Parameters.Add("description", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["description"].Value = aCourse.CourseDescription;

                command.Parameters.Add("deptId", sqlDbType: SqlDbType.Int);
                command.Parameters["deptId"].Value = aCourse.DepartmentId;

                command.Parameters.Add("semesterId", sqlDbType: SqlDbType.Int);
                command.Parameters["semesterId"].Value = aCourse.SemesterId;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<CourseSelectView> GetCoursesByDepartment(int departmentId)
        {
            string query = "SELECT CourseId, CourseCode, CourseName, CourseCredit FROM Courses WHERE DepartmentId =@deptId ORDER BY CourseName ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("deptId", sqlDbType: SqlDbType.Int);
                command.Parameters["deptId"].Value = departmentId;

                List<CourseSelectView> courseSelectViews = new List<CourseSelectView>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CourseSelectView aView = new CourseSelectView
                    {
                        CourseId = Convert.ToInt32(reader["CourseId"].ToString()),
                        CourseCode = reader["CourseCode"].ToString(),
                        CourseName = reader["CourseName"].ToString(),
                        CourseCredit = Convert.ToDecimal(reader["CourseCredit"].ToString())
                    };
                    courseSelectViews.Add(aView);
                }
                return courseSelectViews;
            }
        }

        public List<CourseSelectView> GetAvailableCoursesForStudent(int studentId, int departmentId)
        {
            string query = "SELECT C.CourseId, C.CourseCode, C.CourseName, C.CourseCredit FROM Courses C WHERE C.DepartmentId =@deptId AND C.CourseId NOT IN(SELECT E.CourseId FROM Enrollments E WHERE E.IsCurrent =1 AND E.StudentId =@stdId) ORDER BY C.CourseName ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("deptId", sqlDbType: SqlDbType.Int);
                command.Parameters["deptId"].Value = departmentId;

                command.Parameters.Add("stdId", sqlDbType: SqlDbType.Int);
                command.Parameters["stdId"].Value = studentId;

                List<CourseSelectView> courseSelectViews = new List<CourseSelectView>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CourseSelectView aView = new CourseSelectView
                    {
                        CourseId = Convert.ToInt32(reader["CourseId"].ToString()),
                        CourseCode = reader["CourseCode"].ToString(),
                        CourseName = reader["CourseName"].ToString(),
                        CourseCredit = Convert.ToDecimal(reader["CourseCredit"].ToString())
                    };
                    courseSelectViews.Add(aView);
                }
                return courseSelectViews;
            }
        }

        public List<CourseSelectView> GetAvailableCoursesForTeachers(int departmentId)
        {
            string query = "SELECT C.CourseId, C.CourseCode, C.CourseName, C.CourseCredit FROM Courses C WHERE C.DepartmentId =@deptId AND C.CourseId NOT IN(SELECT A.CourseId FROM CourseAssign A WHERE A.IsCurrent =1) ORDER BY C.CourseName ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("deptId", sqlDbType: SqlDbType.Int);
                command.Parameters["deptId"].Value = departmentId;

                List<CourseSelectView> courseSelectViews = new List<CourseSelectView>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CourseSelectView aView = new CourseSelectView
                    {
                        CourseId = Convert.ToInt32(reader["CourseId"].ToString()),
                        CourseCode = reader["CourseCode"].ToString(),
                        CourseName = reader["CourseName"].ToString(),
                        CourseCredit = Convert.ToDecimal(reader["CourseCredit"].ToString())
                    };
                    courseSelectViews.Add(aView);
                }
                return courseSelectViews;
            }
        }

        public List<CourseStaticsView> GetCourseStaticsByDepartment(int departmentId)
        {
            string query = "SELECT C.CourseCode, C.CourseName, S.SemesterName, T.TeacherName FROM Courses C LEFT JOIN Semesters S ON C.SemesterId = S.SemesterId LEFT JOIN CourseAssign A ON (C.CourseId = A.CourseId AND A.IsCurrent =1 ) LEFT JOIN Teachers T ON A.TeacherId = T.TeacherId WHERE C.DepartmentId =@deptId ORDER BY C.CourseCode ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("deptId", sqlDbType: SqlDbType.Int);
                command.Parameters["deptId"].Value = departmentId;

                List<CourseStaticsView> courseStatics = new List<CourseStaticsView>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CourseStaticsView aStaticsView = new CourseStaticsView
                    {
                        CourseCode = reader["CourseCode"].ToString(),
                        CourseName = reader["CourseName"].ToString(),
                        SemesterName = reader["SemesterName"].ToString(),
                        TeacherName = reader["TeacherName"].ToString()
                    };
                    courseStatics.Add(aStaticsView);
                }
                return courseStatics;
            }
        }

        public List<CourseSelectView> GetEnrolledCourses(int studentId)
        {
            string query = "SELECT C.CourseId, C.CourseCode, C.CourseName, C.CourseCredit FROM Enrollments E LEFT JOIN Courses C ON E.CourseId = C.CourseId WHERE E.StudentId =@studentId AND E.IsCurrent =1 ORDER BY C.CourseName ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("studentId", sqlDbType: SqlDbType.Int);
                command.Parameters["studentId"].Value = studentId;

                List<CourseSelectView> courseSelectViews = new List<CourseSelectView>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CourseSelectView aView = new CourseSelectView
                    {
                        CourseId = Convert.ToInt32(reader["CourseId"].ToString()),
                        CourseCode = reader["CourseCode"].ToString(),
                        CourseName = reader["CourseName"].ToString(),
                        CourseCredit = Convert.ToDecimal(reader["CourseCredit"].ToString())
                    };
                    courseSelectViews.Add(aView);
                }
                return courseSelectViews;
            }
        }

        public List<CourseSelectView> GetAvailableEnrolledCourses(int studentId)
        {
            string query = "SELECT C.CourseId, C.CourseCode, C.CourseName, C.CourseCredit FROM Enrollments E LEFT JOIN Courses C ON E.CourseId = C.CourseId WHERE E.StudentId =@studentId  AND E.IsCurrent =1 AND C.CourseId NOT IN( SELECT R.CourseId FROM StudentResults R WHERE R.StudentId =@studentId AND R.IsCurrent =1 ) ORDER BY C.CourseName ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("studentId", sqlDbType: SqlDbType.Int);
                command.Parameters["studentId"].Value = studentId;

                List<CourseSelectView> courseSelectViews = new List<CourseSelectView>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CourseSelectView aView = new CourseSelectView
                    {
                        CourseId = Convert.ToInt32(reader["CourseId"].ToString()),
                        CourseCode = reader["CourseCode"].ToString(),
                        CourseName = reader["CourseName"].ToString(),
                        CourseCredit = Convert.ToDecimal(reader["CourseCredit"].ToString())
                    };
                    courseSelectViews.Add(aView);
                }
                return courseSelectViews;
            }
        }
    }
}