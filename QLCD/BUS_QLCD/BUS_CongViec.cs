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

        public async Task<List<DTO_CongViec>> GetAllJobs(string citizenId)
        {
            return await _jobDAL.GetAllJobs(citizenId);
        }

        public async Task<List<DTO_CongViec>> GetAllJobsM()
        {
            return await _jobDAL.GetAllJobsM(); // Gọi phương thức từ DAL
        }

        public async Task AddJob(DTO_CongViec job, string citizenId)
        {
            if (ValidateJob(job))
            {
                await _jobDAL.AddJob(job, citizenId);
            }
            else
            {
                throw new ArgumentException("Invalid job information.");
            }
        }

        public async Task UpdateJob(DTO_CongViec job, string citizenId)
        {
            if (ValidateJob(job))
            {
                await _jobDAL.UpdateJob(job, citizenId);
            }
            else
            {
                throw new ArgumentException("Invalid job information.");
            }
        }

        public async Task DeleteJob(string company, string position, string citizenId)
        {
            await _jobDAL.DeleteJob(company, position, citizenId);
        }

        private bool ValidateJob(DTO_CongViec job)
        {
            return !string.IsNullOrEmpty(job.Company) && job.Salary > 0 && !string.IsNullOrEmpty(job.Position);
        }
        public async Task<List<DTO_CongViec>> SearchJobs(string citizenId, string company, string position)
        {
            // Gọi phương thức tìm kiếm trong DAL
            return await _jobDAL.SearchJobs(citizenId, company, position);
        }
    }
}
