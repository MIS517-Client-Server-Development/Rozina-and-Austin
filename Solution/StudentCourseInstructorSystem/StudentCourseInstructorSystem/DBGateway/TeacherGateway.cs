using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DBGateway
{
    public class TeacherGateway : Gateway
    {
        public List<Designation> GetAllDesignations()
        {
            string query = "SELECT * FROM Designations ORDER BY DesignationId ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                List<Designation> designations = new List<Designation>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Designation aDesignation = new Designation
                    {
                        DesignationId = Convert.ToInt32(reader["DesignationId"].ToString()),
                        DesignationName = reader["DesignationName"].ToString()
                    };
                    designations.Add(aDesignation);

                }
                return designations;
            }
        }

        public bool IsEmailExists(string teacherEmail)
        {
            string query = "SELECT * FROM Teachers WHERE TeacherEmail =@email";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("email", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["email"].Value = teacherEmail;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public void Save(Teacher aTeacher)
        {
            string query = "INSERT INTO Teachers (TeacherName, TeacherAddress, TeacherEmail, TeacherContactNo, CreditTaken, DesignationId, DepartmentId) VALUES (@name, @address, @email, @contact, @creditTaken, @designationId, @deptId)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("name", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["name"].Value = aTeacher.TeacherName;

                command.Parameters.Add("address", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["address"].Value = aTeacher.TeacherAddress;

                command.Parameters.Add("email", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["email"].Value = aTeacher.TeacherEmail;

                command.Parameters.Add("contact", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["contact"].Value = aTeacher.TeacherContactNo;

                command.Parameters.Add("creditTaken", sqlDbType: SqlDbType.Decimal);
                command.Parameters["creditTaken"].Value = aTeacher.CreditTaken;

                command.Parameters.Add("designationId", sqlDbType: SqlDbType.Int);
                command.Parameters["designationId"].Value = aTeacher.DesignationId;

                command.Parameters.Add("deptId", sqlDbType: SqlDbType.Int);
                command.Parameters["deptId"].Value = aTeacher.DepartmentId;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Teacher> GetTeachersByDepartment(int departmentId)
        {
            string query = "SELECT * FROM Teachers WHERE DepartmentId =@deptId ORDER BY TeacherName ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("deptId", sqlDbType: SqlDbType.Int);
                command.Parameters["deptId"].Value = departmentId;

                List<Teacher> teachers = new List<Teacher>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Teacher aTeacher = new Teacher
                    {
                        TeacherId = Convert.ToInt32(reader["TeacherId"].ToString()),
                        TeacherName = reader["TeacherName"].ToString(),
                        TeacherAddress = reader["TeacherAddress"].ToString(),
                        TeacherEmail = reader["TeacherEmail"].ToString(),
                        TeacherContactNo = reader["TeacherContactNo"].ToString(),
                        CreditTaken = Convert.ToDecimal(reader["CreditTaken"].ToString()),
                        DesignationId = Convert.ToInt32(reader["DesignationId"].ToString()),
                        DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString())
                    };
                    teachers.Add(aTeacher);
                }
                return teachers;
            }
        }

        public decimal GetCreditUsedByTeacherId(int teacherId)
        {
            string query = "SELECT ISNULL(SUM(C.CourseCredit), 0) AS TotalCredit FROM CourseAssign A LEFT JOIN Courses C ON A.CourseId = C.CourseId WHERE A.IsCurrent =1 AND A.TeacherId =@teacherId";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("teacherId", sqlDbType: SqlDbType.Int);
                command.Parameters["teacherId"].Value = teacherId;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                decimal creditUsed = 0;
                if (reader.Read())
                {
                    creditUsed = Convert.ToDecimal(reader["TotalCredit"].ToString());
                }
                return creditUsed;
            }
        }

        public bool IsAlreadyAssigned(CourseAssign courseAssign)
        {
            string query = "SELECT * FROM CourseAssign WHERE CourseId =@courseId AND IsCurrent =1";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();

                command.Parameters.Add("courseId", sqlDbType: SqlDbType.Int);
                command.Parameters["courseId"].Value = courseAssign.CourseId;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public void AssignCourse(CourseAssign courseAssign)
        {
            string query = "INSERT INTO CourseAssign (TeacherId, CourseId, IsCurrent) VALUES (@teacherId, @courseId, @isCurrent)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("teacherId", sqlDbType: SqlDbType.Int);
                command.Parameters["teacherId"].Value = courseAssign.TeacherId;

                command.Parameters.Add("courseId", sqlDbType: SqlDbType.Int);
                command.Parameters["courseId"].Value = courseAssign.CourseId;

                command.Parameters.Add("isCurrent", sqlDbType: SqlDbType.Bit);
                command.Parameters["isCurrent"].Value = courseAssign.IsCurrent;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}