using Data.Entittes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class TeacherViewModel
    {
        public TeacherViewModel(Teacher teacher)
        {
            TeacherId = teacher.TeacherId;
            Name = teacher.Name;
            Age = teacher.Age;
            Qualification = teacher.Qualification;
            Subject = teacher.Subject;
            MobileNo = teacher.MobileNo;
            EmailAddress = teacher.EmailAddress;
            UserName = teacher.UserName;
            Password = teacher.Password;
            ClassTeacher = teacher.ClassTeacher;
            Desription = teacher.Desription;
        }

        public TeacherViewModel()
        {
            
        }
        public int TeacherId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string ClassTeacher { get; set; }
        [Required]
        public string Desription { get; set; }
    }
}
