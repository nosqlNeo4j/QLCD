using DAL_QLCD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLCD;

namespace BUS_QLCD
{
    public class BUS_CongDan
    {
        private DAL_CongDan _citizenDAL = new DAL_CongDan();

        public async Task<List<DTO_NguoiDan>> GetAllCitizensAsync()
        {
            return await _citizenDAL.GetAllCitizensAsync();
        }

        public void AddCitizen(DTO_NguoiDan citizen)
        {
            if (ValidateCitizen(citizen))
            {
                _citizenDAL.AddCitizen(citizen);
            }
        }

        public void UpdateCitizen(DTO_NguoiDan citizen)
        {
            if (ValidateCitizen(citizen))
            {
                _citizenDAL.UpdateCitizen(citizen);
            }
        }

        public void DeleteCitizen(string id)
        {
            _citizenDAL.DeleteCitizen(id);
        }

        private bool ValidateCitizen(DTO_NguoiDan citizen)
        {
            return citizen.CCCD.Length == 12; // Example validation
        }
    }
}
