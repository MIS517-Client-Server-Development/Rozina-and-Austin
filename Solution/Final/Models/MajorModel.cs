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
   
        public class MajorModel
        {
            public int ID { get; set; }

            [Required]
            [Display(Name = "Major")]
            public string Major { get; set; }

            [Required]
            [Display(Name = "Level")]
            public string Level { get; set; }
        }

}