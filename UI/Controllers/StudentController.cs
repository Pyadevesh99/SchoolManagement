using BusinessLayerLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels;

namespace UI.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task< IActionResult> Student()
        {
            var ListofStudents = await _studentService.GetAllStudents();
            return View(ListofStudents);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                bool IsStored = await _studentService.AddStudent(studentViewModel);
                if (IsStored)
                {
                    return RedirectToAction("Student");
                }
            }
            return RedirectToAction("Create");
        }
        public async Task<IActionResult> Edit( int StudentId)
        {
            bool Isupdated = await _studentService.EditStudent(StudentId);
            if (Isupdated)
            {
                TempData["Message"] = "Updated Sucessfully.";
            }
                return RedirectToAction("Student");
        }

        public async Task<IActionResult> Delete(int StudentId)
        {
            _studentService.DeleteStudent(StudentId);
            return RedirectToAction("Student");
        }
    }
}
