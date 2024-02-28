using BusinessLayerLogic.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels;

namespace UI.Controllers
{
    public class RegisterController : Controller
    {

        private IAccountServices _accountService;

        public RegisterController(IAccountServices accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var IsAdded =  await _accountService.Register(registerViewModel);
            if(IsAdded)
                return RedirectToAction("Login", "Login");
            else
                return RedirectToAction("Register");
        }
    }
}
