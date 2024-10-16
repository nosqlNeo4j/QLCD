using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLCD
{
    public class AddressDTO
    {
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public AddressDTO(string street, string district, string city, string country, string postalCode)
        {
            Street = street;
            District = district;
            City = city;
            Country = country;
            PostalCode = postalCode;
        }
    }
}
