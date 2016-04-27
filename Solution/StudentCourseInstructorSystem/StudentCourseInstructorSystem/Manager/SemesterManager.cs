using System.Collections.Generic;
using UniversityManagementApp.DBGateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class SemesterManager
    {
        SemesterGateway aSemesterGateway = new SemesterGateway();
        public List<Semester> GetAllSemesters()
        {
            return aSemesterGateway.GetAllSemesters();
        }
    }
}