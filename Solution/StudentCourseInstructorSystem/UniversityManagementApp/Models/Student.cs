using System;

namespace UniversityManagementApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string RegNo { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentContactNo { get; set; }
        public string StudentAddress { get; set; }
        public int DepartmentId { get; set; }
        public DateTime RegDate { get; set; }
    }
}