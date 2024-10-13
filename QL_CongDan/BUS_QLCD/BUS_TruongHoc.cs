using DAL_QLCD;
using DTO_QLCD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLCD
{
    public class BUS_TruongHoc
    {
        private DAL_TruongHoc _schoolDAL = new DAL_TruongHoc();

        public List<DTO_TruongHoc> GetAllSchools()
        {
            return _schoolDAL.GetAllSchools();
        }

        public void AddSchool(DTO_TruongHoc school)
        {
            if (ValidateSchool(school))
            {
                _schoolDAL.AddSchool(school);
            }
        }

        public void UpdateSchool(DTO_TruongHoc school)
        {
            if (ValidateSchool(school))
            {
                _schoolDAL.UpdateSchool(school);
            }
        }

        public void DeleteSchool(string name)
        {
            _schoolDAL.DeleteSchool(name);
        }

        private bool ValidateSchool(DTO_TruongHoc school)
        {
            return !string.IsNullOrEmpty(school.Name) && school.StartDate < school.EndDate;
        }
    }
}
