using PlannerProject.Helpers;
using PlannerProject.Models;
using PlannerProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerProject.Services.Concrete
{
    public class AuthService : IAuthService
    {
        IUserService _userService;
        public AuthService(IUserService userService)
        {
            _userService = userService;
        }

        public bool ValidateToken(string token)
        {
            return _userService.GetAllUsers().Any(x => x.Password == token);
        }

        public bool ValidateUser(User user, out string token)
        {
            token = string.Empty;
            bool result =_userService.GetAllUsers().Any(x=>x.Username==user.Username&&x.Password==hashWithSalt(user.Password));
            if (result)
            {
                token = hashWithSalt(user.Password);
            }
            return result;
        }
        private string hashWithSalt(string source)
        {
            return Sha1Helper.HashHash(source + Constants.Salt);
        }
    }
}
