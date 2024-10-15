using DAL_QLCD;
using DTO_QLCD;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BUS_QLCD
{
    public class BUS_TruongHoc
    {
        private readonly DAL_TruongHoc _schoolDAL = new DAL_TruongHoc();

        public async Task<List<DTO_TruongHoc>> GetAllSchoolsAsync()
        {
            return await _schoolDAL.GetAllSchoolsAsync();
        }

        public async Task AddSchoolAsync(DTO_TruongHoc school)
        {
            if (ValidateSchool(school))
            {
                await _schoolDAL.AddSchoolAsync(school);
            }
        }

        public async Task UpdateSchoolAsync(DTO_TruongHoc school)
        {
            if (ValidateSchool(school))
            {
                await _schoolDAL.UpdateSchoolAsync(school);
            }
        }

        public async Task DeleteSchoolAsync(string name)
        {
            await _schoolDAL.DeleteSchoolAsync(name);
        }

        private bool ValidateSchool(DTO_TruongHoc school)
        {
            return !string.IsNullOrEmpty(school.Name) && school.StartDate < school.EndDate;
        }
    }
}
