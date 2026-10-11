
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please enter student name")]
        public string StudentName { get; set; }

        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100")]
        public int Sub1 { get; set; }

        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100")]
        public int Sub2 { get; set; }

        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100")]
        public int Sub3 { get; set; }

        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100")]
        public int Sub4 { get; set; }

        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100")]
        public int Sub5 { get; set; }

        public int Total { get; set; }

        public double Percentage { get; set; }

        public string Result { get; set; }
    }
}
