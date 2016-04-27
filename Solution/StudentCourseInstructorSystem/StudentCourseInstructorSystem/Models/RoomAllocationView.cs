using System;
using System.Collections.Generic;

namespace UniversityManagementApp.Models
{
    public class RoomAllocationView
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        //public List<Schedule> Schedules { get; set; }
        public string RoomNo { get; set; }
        public string DayName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}