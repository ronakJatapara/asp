using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication3.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


       [Required]
       [Column(TypeName ="decimal(18,2)")]
       public decimal Price { get; set; }
        public int AuthorId { get; set; }


        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set;}
    }
}
