using DAL_QLCD;
using DTO_QLCD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLCD
{
    public class BUS_DiaChi
    {
        private DAL_DiaChi _addressDAL = new DAL_DiaChi();

        public List<DTO_DiaChi> GetAllAddresses()
        {
            return _addressDAL.GetAllAddresses();
        }

        public void AddAddress(DTO_DiaChi address)
        {
            if (ValidateAddress(address))
            {
                _addressDAL.AddAddress(address);
            }
        }

        public void UpdateAddress(DTO_DiaChi address)
        {
            if (ValidateAddress(address))
            {
                _addressDAL.UpdateAddress(address);
            }
        }

        public void DeleteAddress(string street)
        {
            _addressDAL.DeleteAddress(street);
        }

        private bool ValidateAddress(DTO_DiaChi address)
        {
            return !string.IsNullOrEmpty(address.Street) && !string.IsNullOrEmpty(address.City);
        }
    }
}
