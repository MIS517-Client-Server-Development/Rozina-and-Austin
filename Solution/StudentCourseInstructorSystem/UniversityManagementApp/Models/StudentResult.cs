
namespace UniversityManagementApp.Models
{
    public class StudentResult
    {
        public int ResultId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int GradeId { get; set; }
        public bool IsCurrent { get; set; }

        public StudentResult()
        {
            IsCurrent = true;
        }
    }
}