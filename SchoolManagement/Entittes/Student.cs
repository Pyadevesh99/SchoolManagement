using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entittes
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Name {  get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public int Rollno { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
