using Data.Entittes;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLogic.Services.Interface
{
    public interface IAccountServices
    {
        Task<LoginViewModel> Login(LoginViewModel loginViewmodel);

        Task<bool> Register(RegisterViewModel registerViewmodel);

        Task<ProfileViewmodel> GetUserDetailsById(int id);
    }
}
