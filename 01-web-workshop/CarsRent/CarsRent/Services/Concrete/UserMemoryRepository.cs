using CarsRent.Helpers;
using CarsRent.Models;
using CarsRent.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsRent.Services.Concrete
{
    public class UserMemoryRepository : IRepository<User>
    {
        private List<User> _users = new List<User> { 
        new User{Username="admin",Password=Sha1Helper.HashHash("admin"+Constants.Salt)}
        
        };
        public void Add(User item)
        {
            _users.Add(item);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
    }
}
