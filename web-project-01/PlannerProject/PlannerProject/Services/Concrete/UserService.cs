using PlannerProject.Helpers;
using PlannerProject.Models;
using PlannerProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerProject.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public void CreateUser(User user)
        {
            user.Password = Sha1Helper.HashHash(user.Password + Constants.Salt);
            _repository.Add(user);
        }
        public List<User> GetAllUsers()
        {
            return _repository.GetAll().ToList();
        }
    }
}
