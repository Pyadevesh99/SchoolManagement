using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLogic.Services.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentViewModel>> GetAllStudents();

        Task<bool> AddStudent(StudentViewModel studentViewModel);

        Task<bool> EditStudent(int StudentId);

        void DeleteStudent(int StudentId);


    }
}
