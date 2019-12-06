using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_01.Models;
using tutorial_01.Services.Abstraction;

namespace tutorial_01.Services.Concrete
{
    public class ContactService : IContactService
    {
        public IEnumerable<Contact> GetContacts()
        {
            return new List<Contact>
            {
                new Contact {Name="Vasili", Phone="7777"},
                new Contact {Name="PoliceMan", Phone="123"},
                new Contact {Name="EmergencyCall", Phone="102"},
            };
        }
    }
}
