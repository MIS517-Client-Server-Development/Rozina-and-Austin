using System.Collections.Generic;
using UniversityManagementApp.DBGateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class GradeManager
    {
        GradeGateway aGradeGateway = new GradeGateway();
        public List<Grade> GetAllGrades()
        {
            return aGradeGateway.GetAllGrades();
        }
    }
}