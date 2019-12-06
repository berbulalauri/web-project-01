using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_03.Models;
using tutorial_03.Services.Abstraction;

namespace tutorial_03.Services.Concrete
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
            Phone="7777",
            Position="Junior"
            },
            new Contact   {
            Name="berdia",
            Phone="123123123",
            Position="Senior"
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
