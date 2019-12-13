using CarsRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsRent.Services.Abstract
{
    public interface IUserService
    {
        void CreateUser(User user);
        List<User> GetAllUsers();
    }
}
