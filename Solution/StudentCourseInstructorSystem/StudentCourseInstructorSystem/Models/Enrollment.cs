using System;

namespace UniversityManagementApp.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsCurrent { get; set; }

        public Enrollment()
        {
            IsCurrent = true;
        }
    }
}