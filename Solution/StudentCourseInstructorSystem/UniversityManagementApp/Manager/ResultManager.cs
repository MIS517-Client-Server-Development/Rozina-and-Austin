using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementApp.DBGateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class ResultManager
    {
        ResultGateway aResultGateway = new ResultGateway();
        public ActionResponse Save(StudentResult aStudentResult)
        {
            ActionResponse response = new ActionResponse();
            try
            {
                bool isAlreadySaved = aResultGateway.IsAlreadySaved(aStudentResult);
                if (isAlreadySaved)
                {
                    response.Class = "danger";
                    response.Message = "This result is already saved.";
                    return response;
                }

                aResultGateway.Save(aStudentResult);
                response.Class = "success";
                response.Message = "Reasult Saved Successfully.";
            }
            catch (SqlException ex)
            {
                response.Class = "warning";
                response.Message = ex.Message;
            }
            return response;
        }

        public List<ResultView> GetResultViewByStudent(int studentId)
        {
            return aResultGateway.GetResultViewByStudent(studentId);
        }
    }
}