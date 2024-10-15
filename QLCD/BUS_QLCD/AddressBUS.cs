using System;
using DAL_QLCD;
using DTO_QLCD;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLCD
{
    public class AddressBUS
    {
        private readonly AddressDAL _addressDAL;

        public AddressBUS(string uri, string user, string password)
        {
            _addressDAL = new AddressDAL(uri, user, password);
        }

        public Task<List<AddressDTO>> GetAllAddresses()
        {
            return _addressDAL.GetAllAddressesAsync();
        }

        public Task AddAddress(AddressDTO address)
        {
            return _addressDAL.AddAddressAsync(address);
        }

        public Task DeleteAddress(string street)
        {
            return _addressDAL.DeleteAddressAsync(street);
        }

        public Task UpdateAddress(string oldStreet, AddressDTO newAddress)
        {
            return _addressDAL.UpdateAddressAsync(oldStreet, newAddress);
        }
    }
}
