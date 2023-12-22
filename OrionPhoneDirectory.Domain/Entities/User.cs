using OrionPhoneDirectory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPhoneDirectory.Domain.Entities
{
    public class User : BaseEntity
    {
        public User() 
        { 
            Contacts = new List<Contact>();
        }
                
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }        
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        //bir kullanicinin birden fazla kontakt kurdugu kisi olabilir
        public List<Contact> Contacts { get; }
    }
}
