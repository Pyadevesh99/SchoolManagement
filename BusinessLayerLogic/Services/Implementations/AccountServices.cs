using BusinessLayerLogic.Services.Interface;
using Data.Entittes;
using Data.UnitOfWork.Interface;
using Model.Enums;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLogic.Services.Implementations
{
    public class AccountServices : IAccountServices
    {
        private IUnitOfWork _unitOfWork;

        public AccountServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginViewModel> Login(LoginViewModel loginViewmodel)
        {
            var user = await _unitOfWork.GenericRepositiory<Users>().GetAll();
            var user1 = user.FirstOrDefault(x => x.UserName == loginViewmodel.UserName && x.Password == loginViewmodel.Password);
            if (user1 != null)
            {
                loginViewmodel.Role = user1.Role;
                loginViewmodel.Name = user1.Name;
                loginViewmodel.Id = user1.Id;
                return loginViewmodel;
            }
            return null;

        }

        public async Task<bool> Register(RegisterViewModel registerViewmodel)
        {
            Users _UsertoBeAdded = new Users()
            {
                Name = registerViewmodel.Name,
                UserName = registerViewmodel.UserName,
                Password = registerViewmodel.Password,
                Role = registerViewmodel.Role,
                Address = registerViewmodel.Address
            };
            var users = _unitOfWork.GenericRepositiory<Users>().AddSync(_UsertoBeAdded);
            _unitOfWork.save();
            if (users != null)
            {
                return true;
            }
            else
                return false;
        }

        public async Task<ProfileViewmodel> GetUserDetailsById(int id)
        {
            var _userDetails = _unitOfWork.GenericRepositiory<Users>().GetById(id);
            if(_userDetails != null)
            {
                ProfileViewmodel profileViewmodel = new ProfileViewmodel()
                {
                    Name = _userDetails.Name,
                    UserName = _userDetails.UserName,
                    Role = _userDetails.Role.ToString(),
                    Address = _userDetails.Address
                };
                return profileViewmodel;
            }
            return null;
        }
    }
}
