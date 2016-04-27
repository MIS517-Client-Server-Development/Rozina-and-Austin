namespace UniversityManagementApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public float CourseCredit { get; set; }
        public string CourseDescription { get; set; }
        public int DepartmentId { get; set; }
        public int SemesterId { get; set; }
    }
}