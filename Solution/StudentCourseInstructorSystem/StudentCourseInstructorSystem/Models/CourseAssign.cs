using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class CourseAssign
    {
        public int AssignId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public bool IsCurrent { get; set; }
        public CourseAssign()
        {
            IsCurrent = true;
        }
    }
}