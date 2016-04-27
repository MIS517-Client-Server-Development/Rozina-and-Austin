using System;

namespace UniversityManagementApp.Models
{
    public class RoomAllocation
    {
        public int AllocationId { get; set; }
        public int RoomId { get; set; }
        public int CourseId { get; set; }
        public int DayId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsCurrent { get; set; }

        public RoomAllocation()
        {
            IsCurrent = true;
        }
    }
}