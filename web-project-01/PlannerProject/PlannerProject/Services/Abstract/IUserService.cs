using PlannerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerProject.Services.Abstract
{
    public interface IUserService
    {
        void CreateUser(User user);
        List<User> GetAllUsers();
    }
}
