using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_01.Models;
using practice_01.Services.Abstraction;

namespace practice_01.Services.Concrete
{
    public class AccountInfoService : IAccountInfoService
    {

        List<AccountInfo> _accountInfoStorage = new List<AccountInfo>
        {
            new AccountInfo   {
            //Name="Rustaveli International Airport",
            //City="Tbilisi",
            //IsInternational=true,
            },
            new AccountInfo   {
            //Name="BaTumi International Airport",
            //City="Batumi",
            //IsInternational=false,
            }
            };

        public void AddAccountInfo(AccountInfo content)
        {
            _accountInfoStorage.Add(content);
        }
        public IEnumerable<AccountInfo> GetAccountInfo()
        {
            return _accountInfoStorage;
        }
    }
}
