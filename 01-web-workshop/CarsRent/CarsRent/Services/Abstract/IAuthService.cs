using CarsRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsRent.Services.Abstract
{
    public interface IAuthService
    {
        bool ValidateUser(User user,out string token);
        bool ValidateToken( string token);
    }
}
