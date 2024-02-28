using Data.Entittes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Model.Validation;

namespace Model.ViewModels
{
    public class StudentViewModel
    {
        private global::Data.Entittes.Student x;

        public StudentViewModel(Student student)
        {
            StudentId = student.StudentId;
            Name = student.Name;
            Rollno = student.Rollno;
            Class = student.Class;
            Description = student.Description;
        }
        public StudentViewModel()
        {

        }
        public int StudentId { get; set; }
        [RequiredField(ErrorMessage ="Name Field Cannot be Empty")]
        public string Name { get; set; }
        [Required]
        [RequiredField]
        public string Class { get; set; }
        [Required]
        public int Rollno { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
