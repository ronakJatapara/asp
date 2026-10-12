using StudentAcedamic.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace StudentAcedamic.Models
{
    public class Student
    {
        public int Id { get; set;  }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RollNo { get; set; }

        [Required]
        public string Course { get; set; }

        public Mark Mark { get; set; }


    }
}
