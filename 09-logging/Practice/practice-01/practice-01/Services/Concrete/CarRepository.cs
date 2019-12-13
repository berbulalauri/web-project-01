using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_01.Models;
using practice_01.Services.Abstract;

namespace practice_01.Services.Concrete
{
    public class CarRepository : IRepository<AccountInfo>
    {
        List<AccountInfo> _cars = new List<AccountInfo>();
        public void Add(AccountInfo item)
        {
            _cars.Add(item);
        }

        public IEnumerable<AccountInfo> GetAll()
        {
            return _cars;
        }
    }
}
