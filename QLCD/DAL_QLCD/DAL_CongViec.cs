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
        public async Task<List<DTO_CongViec>> GetAllJobs(string citizenId)
        {
            var jobs = new List<DTO_CongViec>();
            var columns = new List<string> { "company", "position", "startDate", "salary" }; // Tạo danh sách các cột

            var query = $@"
            MATCH (c:Citizen {{id: '{citizenId}'}})-[:WORKS_AT]->(j:Job)
            RETURN j.company AS company, j.position AS position, j.start_date AS startDate, j.salary AS salary";

            var result = await neo.ExecuteQueryAsync(query, columns); // Truyền columns vào

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

        public async Task<List<DTO_CongViec>> GetAllJobsM()
        {
            var columns = new List<string> { "company", "position", "startDate", "salary", "citizenId" }; // Tạo danh sách các cột

            var query = "MATCH (j:Job) RETURN j.company AS company, j.position AS position, j.start_date AS startDate, j.salary AS salary, j.citizenId AS citizenId";

            var result = await neo.ExecuteQueryAsync(query, columns); // Truyền columns vào
            var jobs = new List<DTO_CongViec>();

            foreach (DataRow row in result.Rows)
            {
                jobs.Add(new DTO_CongViec
                {
                    ID_CongDan = row["citizenId"].ToString(),
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

            var checkResult = await neo.ExecuteQueryCongViecAsync(checkQuery);
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

            await neo.ExecuteQueryCongViecAsync(query);
        }

        public async Task UpdateJob(DTO_CongViec job, string citizenId)
        {
            // Logic to update a job in the database
            var query = $@"
                MATCH (c:Citizen {{id: '{citizenId}'}})-[:WORKS_AT]->(j:Job {{company: '{job.Company}', position: '{job.Position}'}})
                SET j.company = '{job.Company}', j.position = '{job.Position}', j.salary = {job.Salary}
                RETURN j";

            await neo.ExecuteQueryCongViecAsync(query);
        }

        public async Task DeleteJob(string company, string position, string citizenId)
        {
            // Logic to delete a job from the database
            var query = $@"
                MATCH (c:Citizen {{id: '{citizenId}'}})-[:WORKS_AT]->(j:Job {{company: '{company}', position: '{position}'}})
                DELETE j";

            await neo.ExecuteQueryCongViecAsync(query);
        }
        public async Task<List<DTO_CongViec>> SearchJobs(string citizenId, string company, string position)
        {
            var columns = new List<string> { "company", "position", "startDate", "salary" }; // Tạo danh sách các cột

            var query = $@"
            MATCH (c:Citizen {{id: '{citizenId}'}})-[:WORKS_AT]->(j:Job)
            WHERE j.company CONTAINS '{company}' AND j.position CONTAINS '{position}'
            RETURN j.company AS company, j.position AS position, j.start_date AS startDate, j.salary AS salary";

            var result = await neo.ExecuteQueryAsync(query, columns); // Truyền columns vào
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

        public async Task<bool> CheckDuplicateJob(string company, string position, string citizenId)
        {
            string query = $@"
            MATCH (c:Citizen {{id: '{citizenId}'}})-[:WORKS_AT]->(j:Job {{company: '{company}', position: '{position}'}})
            RETURN COUNT(j) AS count";

            var result = await neo.ExecuteQueryCongViecAsync(query);
            var count = Convert.ToInt32(result.Rows[0]["count"]);

            return count > 0; // Trả về true nếu có công việc trùng lặp
        }

    }
}
