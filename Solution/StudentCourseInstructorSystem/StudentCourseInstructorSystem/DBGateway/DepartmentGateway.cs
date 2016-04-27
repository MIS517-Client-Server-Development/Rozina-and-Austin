using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DBGateway
{
    public class DepartmentGateway : Gateway
    {
        public bool IsDepartmentCodeExists(string departmentCode)
        {
            string query = "SELECT * FROM Departments WHERE DepartmentCode =@departmentCode";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("departmentCode", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["departmentCode"].Value = departmentCode;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public bool IsDepartmentNameExists(string departmentName)
        {
            string query = "SELECT * FROM Departments WHERE DepartmentName =@name";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("name", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["name"].Value = departmentName;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public void Save(Department aDepartment)
        {
            string query = "INSERT INTO Departments (DepartmentCode, DepartmentName) VALUES (@code, @name)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Clear();
                command.Parameters.Add("code", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["code"].Value = aDepartment.DepartmentCode;

                command.Parameters.Add("name", sqlDbType: SqlDbType.NVarChar);
                command.Parameters["name"].Value = aDepartment.DepartmentName;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public List<Department> GetAllDepartments()
        {
            string query = "SELECT * FROM Departments ORDER BY DepartmentName ASC";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                List<Department> departments = new List<Department>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Department aDepartment = new Department
                    {
                        DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString()),
                        DepartmentCode = reader["DepartmentCode"].ToString(),
                        DepartmentName = reader["DepartmentName"].ToString()
                    };
                    departments.Add(aDepartment);

                }
                return departments;
            }
        }

        public string GetDepartmentCodeById(int departmentId)
        {
            string query = "SELECT DepartmentCode FROM Departments WHERE DepartmentId =@id";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                string deptCode = "";
                command.Parameters.Clear();
                command.Parameters.Add("id", sqlDbType: SqlDbType.Int);
                command.Parameters["id"].Value = departmentId;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    deptCode = reader["DepartmentCode"].ToString();
                }
                return deptCode;
            }
        }
    }
}
