using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_02.Models;

namespace tutorial_02.Services.Abstraction
{
    public interface IContactService
    {
        public IEnumerable<Contact> GetContacts();
        void AddContact(Contact contact);
    }
}
