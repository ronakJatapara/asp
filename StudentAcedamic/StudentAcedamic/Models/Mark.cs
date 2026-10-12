using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAcedamic.Models
{
    public class Mark
    {
        public int Id { get; set; } 

        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        [Range(0,100)]
        public int Maths { get; set; }

        [Range(0, 100)]
        public int Science { get; set; }

        [Range(0, 100)]
        public int English { get; set; }

        [Range(0, 100)]
        public int Computer { get; set; }

        public int Total { get; set; }

        public double Percentage { get; set; }

        public string Result { get; set; }



    }
}
