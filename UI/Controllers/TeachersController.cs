using BusinessLayerLogic.Services.Implementations;
using BusinessLayerLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels;

namespace UI.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> Teacher()
        {
            var ListofTeachers = await _teacherService.GetAllTeachers();
            return View(ListofTeachers);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(TeacherViewModel teacherViewModel)
        {
            if (ModelState.IsValid)
            {
                bool IsStored = await _teacherService.AddTeacher(teacherViewModel);
                if (IsStored)
                {
                    return RedirectToAction("Teacher");
                }
            }
            return RedirectToAction("Create");
        }
    }
}
