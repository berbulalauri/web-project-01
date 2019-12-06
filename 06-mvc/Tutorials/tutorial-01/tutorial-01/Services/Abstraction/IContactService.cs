using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_01.Models;

namespace tutorial_01.Services.Abstraction
{
    public interface IContactService
    {
        public IEnumerable<Contact> GetContacts();
    }
}
