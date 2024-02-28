using BusinessLayerLogic.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Enums;
using Model.ViewModels;
using System.Diagnostics;
using System.Text.Json;
using UI.Models;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        private readonly IAccountServices _accountServices;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(IAccountServices accountServices, IHttpContextAccessor httpContextAccessor, ILogger<LoginController> logger)
        {
            _accountServices = accountServices;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Login(LoginViewModel loginViewModel)
        {
            LoginViewModel _UserValue = await _accountServices.Login(loginViewModel);
            if(_UserValue != null)
            {
                string SessionObject = JsonSerializer.Serialize(_UserValue);
                //HttpContext.Session.SetString("SessionObject", SessionObject);
                HttpContext.Session.SetString("Id", _UserValue.Id.ToString());
                //HttpContext.Session.SetString("UserName", loginViewModel.UserName);
                //HttpContext.Session.SetString("Password", loginViewModel.Password);
                //HttpContext.Session.SetString("Role", loginViewModel.Role.ToString());
                return RedirectToUser(_UserValue);
            }
            return View(loginViewModel);
        }
        [Authorize]
        private IActionResult RedirectToUser(LoginViewModel loginValue)
        {
            _NavbarViewModel _NavbarViewModel = new _NavbarViewModel()
            {
                Role = loginValue.Role
            };
            //if (loginValue.Role == (int)EnumRole.Admin)
            //{
                return RedirectToAction("Users", _NavbarViewModel);
            //}
            //else if (loginValue.Role == (int)EnumRole.Teacher)
            //{
            //    return RedirectToAction("Index", "Exams");
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Students");
            //}

        }

        [HttpGet]
        public IActionResult Users(_NavbarViewModel _NavbarViewModel)
        {
            if(_NavbarViewModel.Role == 0)
            {
                if(HttpContext.Session.GetString("Id") != null)
                {
                    string username = (HttpContext.Session.GetString("Id") + "").ToString();
                    int user_Id = int.Parse(username);
                    var userDetails = _accountServices.GetUserDetailsById(user_Id);
                    if (userDetails.Result != null)
                    {
                        _NavbarViewModel.Role = int.Parse(userDetails.Result.Role);
                    }
                }
            }
            return View(_NavbarViewModel);
            //return PartialView("../PartialView/_Navbar",_NavbarViewModel);
        }
        [HttpGet]
        public async Task< IActionResult> Profile()
        {
            string username = (HttpContext.Session.GetString("Id") + "").ToString();
            int user_Id = int.Parse(username);
            var userDetails = await _accountServices.GetUserDetailsById(user_Id); 
            if(userDetails != null)
            {
                return View(userDetails);
            }
            return View();
        }

    }
}
