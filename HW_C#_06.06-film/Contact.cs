using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_C__06._06_film
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
