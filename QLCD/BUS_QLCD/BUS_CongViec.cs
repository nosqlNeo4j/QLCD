using DAL_QLCD;
using DTO_QLCD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLCD
{
    public class BUS_CongViec
    {
        private DAL_CongViec _jobDAL = new DAL_CongViec();

        public async Task<List<DTO_CongViec>> GetAllJobsAsync()
        {
            return await _jobDAL.GetAllJobsAsync();
        }

        public void AddJob(DTO_CongViec job)
        {
            if (ValidateJob(job))
            {
                _jobDAL.AddJob(job);
            }
        }

        public void UpdateJob(DTO_CongViec job)
        {
            if (ValidateJob(job))
            {
                _jobDAL.UpdateJob(job);
            }
        }

        public void DeleteJob(string company)
        {
            _jobDAL.DeleteJob(company);
        }

        private bool ValidateJob(DTO_CongViec job)
        {
            return !string.IsNullOrEmpty(job.Company) && job.Salary > 0;
        }
    }
}
