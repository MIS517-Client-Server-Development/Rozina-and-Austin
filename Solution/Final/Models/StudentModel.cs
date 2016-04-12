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
    public class StudentModel
    {


            public int ID { get; set; }

            [Required]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Middle name")]
            public string MiddleName { get; set; }

            [Required]
            [Display(Name = "Gender")]
            public string Gender { get; set; }


            [Required]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required]
            [Display(Name = "ParentGuardian")]
            public string ParentGuardian { get; set; }

            [Required]
            [Display(Name = "Date Of Birth")]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }

            [Required]
            [Display(Name = "Place Of Birth")]
            public string BirthPlace { get; set; }
        }

        public class StudentEntry
        {

            public int ID { get; set; }

            [Required]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Middle name")]
            public string MiddleName { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Gender")]
            public string Gender { get; set; }


            [Required]
            [Display(Name = "Address")]
            public string Address { get; set; }


            [Display(Name = "ParentGuardian")]
            public string ParentGuardian { get; set; }

            [Required]
            [Display(Name = "Date Of Birth")]
            public string BirthDate { get; set; }

            [Required]
            [Display(Name = "Place Of Birth")]
            public string BirthPlace { get; set; }


            //[Display(Name = "Birth Certificate")]
            //public bool IsBirthCertPresent { get; set; }

            //[Display(Name = "Form 137")]
            //public bool IsForm137Preesent { get; set; }

            //[Display(Name = "TOR")]
            //public bool IsTORPresent { get; set; }

            [Display(Name = "Program/Course")]
            public int ProgramID { get; set; }

            [Display(Name = "Major")]
            public int MajorID { get; set; }
        }

        public class StudentCourseSY
        {
            //ID, StudentID, SchYr, Sem, Year, Section, ProgramID, MajorID, Override, Regular, Enrolled, ProgramAlias, Remarks
            public int ID { get; set; }

            public int StudentID { get; set; }

            [Required]
            public int ProgramID { get; set; }

            [Required]
            public int MajorID { get; set; }

            [Display(Name = "Student")]
            public string StudentName { get; set; }

            [Display(Name = "Program")]
            public string Program { get; set; }

            [Display(Name = "Major")]
            public string Major { get; set; }

            [Required]
            [Display(Name = "School Year")]
            public string SchoolYear { get; set; }

            [Required]
            [Display(Name = "Semester")]
            public string Semester { get; set; }

            [Required]
            [Display(Name = "Year")]
            public string Year { get; set; }

            [Required]
            [Display(Name = "Section")]
            public string Section { get; set; }

            [Display(Name = "Is Regular")]
            public bool IsRegular { get; set; }

            [Display(Name = "Is Enrolled")]
            public bool IsEnrolled { get; set; }


            [Display(Name = "Notes")]
            [DataType(DataType.MultilineText)]
            public string Remarks { get; set; }
        }

        public class StudentAndCourse
        {
            public StudentEntry Student { get; set; }
            public StudentCourseSY Course { get; set; }
        }
    }
