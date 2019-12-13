using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_02.Models;
using practice_02.Services.Abstraction;

namespace practice_02.Services.Concrete
{
    public class AccountInfoService : IAccountInfoService
    {

        List<Student> _accountInfoStorage = new List<Student> { };

        public void AddAccountInfo(Student content)
        {
            _accountInfoStorage.Add(content);
        }
        public IEnumerable<Student> GetAccountInfo()
        {
            return _accountInfoStorage;
        }
    }
}
