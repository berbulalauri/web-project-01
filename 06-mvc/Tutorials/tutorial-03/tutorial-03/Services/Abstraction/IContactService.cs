using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_03.Models;

namespace tutorial_03.Services.Abstraction
{
    public interface IContactService
    {
        public IEnumerable<Contact> GetContacts();
        void AddContact(Contact contact);
    }
}
