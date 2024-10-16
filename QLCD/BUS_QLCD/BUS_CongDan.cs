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

        public async Task<List<DTO_NguoiDan>> GetAllCitizens()
        {
            return await _citizenDAL.GetAllCitizens();
        }

        public async Task AddCitizen(DTO_NguoiDan citizen)
        {
            if (ValidateCitizen(citizen))
            {
                await _citizenDAL.AddCitizen(citizen);
            }
            else
            {
                throw new ArgumentException("Citizen data is not valid.");
            }
        }

        public async Task UpdateCitizen(DTO_NguoiDan citizen)
        {
            if (ValidateCitizen(citizen))
            {
                await _citizenDAL.UpdateCitizen(citizen);
            }
            else
            {
                throw new ArgumentException("Citizen data is not valid.");
            }
        }

        public async Task DeleteCitizen(string id)
        {
            await _citizenDAL.DeleteCitizen(id);
        }

        public bool ValidateCitizen(DTO_NguoiDan citizen)
        {
            // Kiểm tra CCCD
            if (string.IsNullOrWhiteSpace(citizen.CCCD) || citizen.CCCD.Length != 12 || !long.TryParse(citizen.CCCD, out _))
            {
                return false; // CCCD phải là một chuỗi không rỗng, dài 12 ký tự và chỉ chứa số
            }

            // Kiểm tra tên
            if (string.IsNullOrWhiteSpace(citizen.Name) || citizen.Name.Length < 2 || citizen.Name.Length > 50)
            {
                return false; // Tên phải không rỗng và từ 2 đến 50 ký tự
            }

            // Kiểm tra ngày sinh
            if (citizen.Birthdate > DateTime.Now || citizen.Birthdate < new DateTime(1900, 1, 1))
            {
                return false; // Ngày sinh phải hợp lệ và không ở tương lai
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(citizen.Phone) || citizen.Phone.Length != 10 || !long.TryParse(citizen.Phone, out _))
            {
                return false; // Số điện thoại phải là chuỗi không rỗng, dài 10 ký tự và chỉ chứa số
            }

            // Kiểm tra email
            if (string.IsNullOrWhiteSpace(citizen.Email) || !IsValidEmail(citizen.Email))
            {
                return false; // Email phải hợp lệ
            }

            // Kiểm tra giới tính
            if (string.IsNullOrWhiteSpace(citizen.Gender) ||
            !(citizen.Gender.Equals("Nam", StringComparison.OrdinalIgnoreCase) ||
            citizen.Gender.Equals("Nữ", StringComparison.OrdinalIgnoreCase)))
            {
                return false; // Giới tính chỉ được phép là "Nam" hoặc "Nữ"
            }

            // Kiểm tra quốc tịch
            if (string.IsNullOrWhiteSpace(citizen.Nationality))
            {
                return false; // Quốc tịch không được để trống
            }

            // Kiểm tra nghề nghiệp
            if (string.IsNullOrWhiteSpace(citizen.Occupation))
            {
                return false; // Nghề nghiệp không được để trống
            }

            return true; // Nếu tất cả các kiểm tra đều hợp lệ
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
