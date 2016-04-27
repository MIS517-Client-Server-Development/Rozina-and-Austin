using System;

namespace UniversityManagementApp.Models
{
    public class Schedule
    {
        public string RoomNo { get; set; }
        public string DayName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}