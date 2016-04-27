using System.Collections.Generic;
using UniversityManagementApp.DBGateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class DayManager
    {
        DayGateway aDayGateway = new DayGateway();
        public List<Day> GetAllDays()
        {
            return aDayGateway.GetAllDays();
        }
    }
}