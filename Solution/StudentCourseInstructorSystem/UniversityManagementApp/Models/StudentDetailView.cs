using System;

namespace UniversityManagementApp.Models
{
    public class StudentDetailView
    {
        public string RegNo { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentContactNo { get; set; }
        public string StudentAddress { get; set; }
        public DateTime RegDate { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}