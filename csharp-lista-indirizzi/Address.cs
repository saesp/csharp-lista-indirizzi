using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    public class Address
    {
        public string Street { get; set; }
        public string City {get; set;}
        public string Province {get; set;}
        public string Zip {get; set;}


        public Address(string street, string city, string province, string zip)
        {
            Street = street;
            City = city;
            Province = province;
            Zip = zip;
        }

    }
}
