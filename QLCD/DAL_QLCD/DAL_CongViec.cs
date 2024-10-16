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
        string uri = "bolt://localhost:7687";
        string username = "neo4j";
        string password = "12345678";
        string database = "testdb";
        Connection_Neo4J neo;
        public DAL_CongViec()
        {
            neo = new Connection_Neo4J(uri, username, password, database);
        }
        public async Task<List<DTO_CongViec>> GetAllJobs(string citizenId)
        {
            // Logic to retrieve all jobs from the database

            var jobs = new List<DTO_CongViec>();

            var query = $@"
                MATCH (c:Citizen {{id: '{citizenId}'}})-[:WORKS_AT]->(j:Job)
                RETURN j.company AS company, j.position AS position, j.start_date AS startDate, j.salary AS salary";

            var result = await neo.ExecuteQueryAsync(query);

            // Duyệt qua các hàng trong DataTable
            foreach (DataRow row in result.Rows)
            {
                jobs.Add(new DTO_CongViec
                {
                    Company = row["company"].ToString(),
                    Position = row["position"].ToString(),
                    StartDate = Convert.ToDateTime(row["startDate"]),
                    Salary = Convert.ToDecimal(row["salary"]) // Sử dụng Convert.ToDecimal
                });
            }

            return jobs;
        }

        public async Task<List<DTO_CongViec>> GetAllJobsM()
        {
            var query = "MATCH (j:Job) RETURN j.company AS company, j.position AS position, j.start_date AS startDate, j.salary AS salary, j.citizenId AS citizenId";

            var result = await neo.ExecuteQueryAsync(query);
            var jobs = new List<DTO_CongViec>();

            foreach (DataRow row in result.Rows)
            {
                jobs.Add(new DTO_CongViec
                {
                    ID_CongDan = row["citizenId"].ToString(), // Lưu CitizenID
                    Company = row["company"].ToString(),
                    Position = row["position"].ToString(),
                    StartDate = Convert.ToDateTime(row["startDate"]),
                    Salary = Convert.ToDecimal(row["salary"])
                });
            }

            return jobs;
        }

        public async Task AddJob(DTO_CongViec job, string citizenId)
        {
            // Logic to add a job to the database
            
            // Kiểm tra trùng lặp
            var checkQuery = $@"
                MATCH (c:Citizen {{id: '{citizenId}'}})-[:WORKS_AT]->(j:Job {{company: '{job.Company}', position: '{job.Position}'}})
                RETURN COUNT(j) AS count";

            var checkResult = await neo.ExecuteQueryAsync(checkQuery);
            var count = Convert.ToInt32(checkResult.Rows[0]["count"]);

            if (count > 0)
            {
                throw new Exception("Job already exists for this citizen.");
            }

            // Thêm công việc mới
            var query = $@"
                MATCH (c:Citizen {{id: '{citizenId}'}})
                CREATE (c)-[:WORKS_AT]->(j:Job {{
                    company: '{job.Company}', 
                    position: '{job.Position}', 
                    start_date: '{job.StartDate:yyyy-MM-dd}', 
                    salary: {job.Salary}
                }})";

            await neo.ExecuteQueryAsync(query);
        }

        public async Task UpdateJob(DTO_CongViec job, string citizenId)
        {
            // Logic to update a job in the database
            var query = $@"
                MATCH (c:Citizen {{id: '{citizenId}'}})-[:WORKS_AT]->(j:Job {{company: '{job.Company}', position: '{job.Position}'}})
                SET j.company = '{job.Company}', j.position = '{job.Position}', j.salary = {job.Salary}
                RETURN j";

            await neo.ExecuteQueryAsync(query);
        }

        public async Task DeleteJob(string company, string position, string citizenId)
        {
            // Logic to delete a job from the database
            var query = $@"
                MATCH (c:Citizen {{id: '{citizenId}'}})-[:WORKS_AT]->(j:Job {{company: '{company}', position: '{position}'}})
                DELETE j";

            await neo.ExecuteQueryAsync(query);
        }
        public async Task<List<DTO_CongViec>> SearchJobs(string citizenId, string company, string position)
        {
            var query = $@"
            MATCH (c:Citizen {{id: '{citizenId}'}})-[:WORKS_AT]->(j:Job)
            WHERE j.company CONTAINS '{company}' AND j.position CONTAINS '{position}'
            RETURN j.company AS company, j.position AS position, j.start_date AS startDate, j.salary AS salary";

            var result = await neo.ExecuteQueryAsync(query);
            var jobs = new List<DTO_CongViec>();

            foreach (DataRow row in result.Rows)
            {
                jobs.Add(new DTO_CongViec
                {
                    Company = row["company"].ToString(),
                    Position = row["position"].ToString(),
                    StartDate = Convert.ToDateTime(row["startDate"]),
                    Salary = Convert.ToDecimal(row["salary"])
                });
            }

            return jobs;
        }
    }
}
