using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleanVersion.Models
{
    public class Attendance_M
    {

        public int Attendance_ID { get; set; }
        public int Date { get; set; }
        public int Hour { get; set; }
        public int Subject_Code { get; set; }
        public int RollNo { get; set; }
        public string Attendance { get; set; }

    }
}