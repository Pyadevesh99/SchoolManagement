using BusinessLayerLogic.Services.Interface;
using Data;
using Data.Entittes;
using Data.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLogic.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<StudentViewModel>> GetAllStudents()
        {
            var students = await _unitOfWork.GenericRepositiory<Student>().GetAll();
            if(students.Count() > 0)
            {
                var StudentViewModel = ListInfo(students);
                return StudentViewModel;
            }
            return new List<StudentViewModel>();
        }
        private List<StudentViewModel> ListInfo(IEnumerable<Student> students)
        {
            return students.Select(x => new StudentViewModel(x)).ToList();
        }

        public async Task<bool> AddStudent(StudentViewModel studentViewModel)
        {
            if(studentViewModel != null)
            {
                var student = new Student()
                {
                    Name = studentViewModel.Name,
                    Rollno = studentViewModel.Rollno,
                    Class = studentViewModel.Class,
                    Description = studentViewModel.Description
                };
               var newstudent= await  _unitOfWork.GenericRepositiory<Student>().AddSync(student);
               _unitOfWork.save();
                if (newstudent != null)
                    return true;
            }
            return false;
        }

        public async Task<bool> EditStudent(int StudentId)
        {
            var StudentNeedTObeUpdate = await _unitOfWork.GenericRepositiory<Student>().GetByIdAsync(StudentId);
            if(StudentNeedTObeUpdate != null)
            {
                var student = await _unitOfWork.GenericRepositiory<Student>().UpdateAsync(StudentNeedTObeUpdate);
                if(student != null)
                    return true;
            }
            return false;
        }

        public void DeleteStudent(int StudentId)
        {
            _unitOfWork.GenericRepositiory<Student>().DeleteById(StudentId);
            _unitOfWork.save();
        }
    }
}
