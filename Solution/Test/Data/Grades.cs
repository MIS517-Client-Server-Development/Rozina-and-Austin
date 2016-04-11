using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleanVersion.Data
{

    struct Student
    {
        public int Student_Id;
        public string UserName;
        public string Password;
        public int Instructor_ID;
        public string LName;
        public string FName;

    }
    struct Instructor
    {
        public int Instructor_ID;
        public string Username;
        public string Password;
        public string LName;
        public string FName;
        public string Class;
    }
    public class Grades
    {

    }

}