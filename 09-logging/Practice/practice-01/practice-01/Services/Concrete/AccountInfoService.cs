using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_01.Models;
using practice_01.Services.Abstract;

namespace practice_01.Services
{
    public class AccountInfoService : IAccountInfoService
    {
        IRepository<AccountInfo> _repository;
        public AccountInfoService(IRepository<AccountInfo> repository)
        {
            _repository = repository;
        }
        public void AddAccountInfo(AccountInfo car)
        {
            _repository.Add(car);
        }
        public List<AccountInfo> GetAccountInfo()
        {
            var cars = _repository.GetAll();
            return cars.OrderBy(x => x.MaxSpeed).ToList();
        }

        //List<AccountInfo> _accountInfoStorage = new List<AccountInfo>
        //{};
        //public void AddAccountInfo(AccountInfo content)
        //{
        //    _accountInfoStorage.Add(content);
        //}
        //public IEnumerable<AccountInfo> GetAccountInfo()
        //{
        //    return _accountInfoStorage;
        //}
    }
}
