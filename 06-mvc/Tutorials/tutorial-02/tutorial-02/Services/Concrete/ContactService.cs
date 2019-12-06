using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_02.Models;
using tutorial_02.Services.Abstraction;

namespace tutorial_02.Services.Concrete
{
    public class ContactService : IContactService
    {
        //public IEnumerable<Contact> GetContacts()
        //{
        //    return new List<Contact>
        //    {
        //        new Contact {Name="Vasili", Phone="7777"},
        //        new Contact {Name="PoliceMan", Phone="123"},
        //    };
        //}

        List<Contact> _storage = new List<Contact>
        {
            new Contact   {
            Name="Vasili",
                Phone="7777"
            },
            new Contact   {
            Name="berdia",
            Phone="123123123"
            }
            };

        public void AddContact(Contact contact)
        {
            _storage.Add(contact);
        }
        public IEnumerable<Contact> GetContacts()
        {
            return _storage;
        }
    }
}
