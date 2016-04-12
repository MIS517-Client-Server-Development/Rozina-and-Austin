using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Final.Models
{
    public class SubjectModel
    {
        // ID, CourseCode, CourseTitle, CourseDesc, Unit, HoursWeek, Program, PreRequesite

        public int ID { get; set; }

        [Required]
        [Display(Name = "Subject Code")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Subject Title")]
        public string SubjectTitle { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Unit")]
        public double Unit { get; set; }


        [Required]
        [Display(Name = "Hours per Week")]
        public int HoursWeek { get; set; }

        [Display(Name = "Prerequisite")]
        public int Prerequisite { get; set; }
    }
}