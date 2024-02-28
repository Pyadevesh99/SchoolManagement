using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLogic.Services.Interface
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherViewModel>> GetAllTeachers();

        Task<bool> AddTeacher(TeacherViewModel teacherViewModel);
    }
}
