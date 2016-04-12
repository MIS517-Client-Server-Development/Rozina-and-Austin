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
    public class ProgramModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Program")]
        public string Program { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}