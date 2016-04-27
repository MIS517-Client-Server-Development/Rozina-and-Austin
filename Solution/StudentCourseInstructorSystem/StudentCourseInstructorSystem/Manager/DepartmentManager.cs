using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementApp.DBGateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
        public ActionResponse Save(Department aDepartment)
        {
            ActionResponse response = new ActionResponse();
            try
            {
                bool isDepartmentCodeExists = aDepartmentGateway.IsDepartmentCodeExists(aDepartment.DepartmentCode);
                if (isDepartmentCodeExists)
                {
                    response.Class = "warning";
                    response.Message = "Department Code [" + aDepartment.DepartmentCode + "] is already exists.";
                    return response;
                }

                bool isDepartmentNameExists = aDepartmentGateway.IsDepartmentNameExists(aDepartment.DepartmentName);
                if (isDepartmentNameExists)
                {
                    response.Class = "warning";
                    response.Message = "Department Name [" + aDepartment.DepartmentName + "] is already exists.";
                    return response;
                }

                aDepartmentGateway.Save(aDepartment);
                response.Class = "success";
                response.Message = "Department Saved Successfully";
            }
            catch (SqlException ex)
            {
                response.Class = "danger";
                response.Message = ex.Message;
            }
            return response;
        }

        public List<Department> GetAllDepartments()
        {
            return aDepartmentGateway.GetAllDepartments();
        }
    }
}