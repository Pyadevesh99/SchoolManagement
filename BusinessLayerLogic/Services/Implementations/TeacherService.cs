using Azure;
using BusinessLayerLogic.Services.Interface;
using Data.Entittes;
using Data.UnitOfWork.Interface;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLogic.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private IUnitOfWork _unitOfWork;

        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TeacherViewModel>> GetAllTeachers()
        {
            var Teachers = await _unitOfWork.GenericRepositiory<Teacher>().GetAll();
            if(Teachers != null)
            {
                var teacherViewModels = ListInfo(Teachers);
                return teacherViewModels;
            }
            return new List<TeacherViewModel>();
        }
        private List<TeacherViewModel> ListInfo(IEnumerable<Teacher> students)
        {
            return students.Select(x => new TeacherViewModel(x)).ToList();
        }

        public async Task<bool> AddTeacher(TeacherViewModel teacherViewModel)
        {
            if (teacherViewModel != null)
            {
                var teacher = new Teacher()
                {
                    Name = teacherViewModel.Name,
                    Age = teacherViewModel.Age,
                    Qualification = teacherViewModel.Qualification,
                    Subject = teacherViewModel.Subject,
                    MobileNo = teacherViewModel.MobileNo,
                    EmailAddress = teacherViewModel.EmailAddress,
                    UserName = teacherViewModel.UserName,
                    Password = teacherViewModel.Password,
                    ClassTeacher = teacherViewModel.ClassTeacher,
                    Desription = teacherViewModel.Desription
            };
                var newstudent = await _unitOfWork.GenericRepositiory<Teacher>().AddSync(teacher);
                _unitOfWork.save();
                if (newstudent != null)
                    return true;
            }
            return false;
        }
    }
}
