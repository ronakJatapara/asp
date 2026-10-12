using System.ComponentModel.DataAnnotations;

namespace StudentAcedamic.ViewModels
{
    public class StudentMarksViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string RollNo { get; set; }

        [Required]
        public string Course { get; set; }

        [Range(0, 100)]
        public int Maths { get; set; }

        [Range(0, 100)]
        public int Science { get; set; }

        [Range(0, 100)]
        public int English { get; set; }

        [Range(0, 100)]
        public int Computer { get; set; }
    }
}
