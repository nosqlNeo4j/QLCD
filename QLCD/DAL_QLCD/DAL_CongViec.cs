using DTO_QLCD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLCD
{
    public class DAL_CongViec
    {
        private readonly string uri = "bolt://localhost:7687";
        private readonly string username = "neo4j";
        private readonly string password = "12345678";
        private readonly string database = "neo4j";
        private readonly Connection_Neo4J neo;
        public DAL_CongViec()
        {
            neo = new Connection_Neo4J(uri, username, password, database);
        }
        public async Task<List<DTO_CongViec>> GetAllJobsAsync()
        {
            List<DTO_CongViec> jobs = new List<DTO_CongViec>();
            string query = @"
            MATCH (j:Job)
            RETURN j.company AS Company, j.position AS Position, 
            j.start_date AS StartDate, j.salary AS Salary";

            var resultTable = await neo.ExecuteQueryCongViecAsync(query);
            foreach (DataRow row in resultTable.Rows)
            {
                DTO_CongViec job = new DTO_CongViec
                {
                    Company = row["Company"]?.ToString(),
                    Position = row["Position"]?.ToString(),
                    StartDate = DateTime.TryParse(row["StartDate"]?.ToString(), out var startDate) ? startDate : DateTime.MinValue,
                    Salary = decimal.TryParse(row["Salary"]?.ToString(), out var salary) ? salary : 0
                };
                jobs.Add(job);
            }
            return jobs;
        }

        public void AddJob(DTO_CongViec job)
        {
            // Logic to add a job to the database
        }

        public void UpdateJob(DTO_CongViec job)
        {
            // Logic to update a job in the database
        }

        public void DeleteJob(string company)
        {
            // Logic to delete a job from the database
        }
    }
}
