using DTO_QLCD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DAL_QLCD
{
    public class DAL_TruongHoc
    {
        private readonly string uri = "bolt://localhost:7687";
        private readonly string username = "neo4j";
        private readonly string password = "12345678";
        private readonly string database = "neo4j";
        private readonly Connection_Neo4J neo;

        public DAL_TruongHoc()
        {
            neo = new Connection_Neo4J(uri, username, password, database);
        }

        public async Task<List<DTO_TruongHoc>> GetAllSchoolsAsync()
        {
            List<DTO_TruongHoc> schools = new List<DTO_TruongHoc>();
            string query = "MATCH (s:School) RETURN s.name AS Name, s.start_date AS StartDate, s.end_date AS EndDate, s.degree AS Degree";
            var resultTable = await neo.ExecuteQueryTruongHocAsync(query);
            foreach (DataRow row in resultTable.Rows)
            {
                DTO_TruongHoc school = new DTO_TruongHoc
                {
                    Name = row["Name"]?.ToString(),
                    StartDate = DateTime.TryParse(row["StartDate"].ToString(), out var startDate) ? startDate : DateTime.Parse(null),
                    EndDate = DateTime.TryParse(row["EndDate"].ToString(), out var endDate) ? endDate : DateTime.Parse(null),
                    Degree = row["Degree"]?.ToString()
                };
                schools.Add(school);
            }
            return schools;
        }

        public async Task AddSchoolAsync(DTO_TruongHoc school)
        {
            string query = $@"
            CREATE (s:School {{
            name: '{school.Name}',
            start_date: '{school.StartDate:yyyy-MM-dd}',
            end_date: '{school.EndDate:yyyy-MM-dd}',
            degree: '{school.Degree}'
            }})";

            await neo.ExecuteQueryTruongHocAsync(query);
        }

        public async Task UpdateSchoolAsync(DTO_TruongHoc school)
        {
            string query = $@"
            MATCH (s:School {{ name: '{school.Name}' }})
            SET s.start_date = '{school.StartDate:yyyy-MM-dd}',
                s.end_date = '{school.EndDate:yyyy-MM-dd}',
                s.degree = '{school.Degree}'";

            await neo.ExecuteQueryTruongHocAsync(query);
        }

        public async Task DeleteSchoolAsync(string name)
        {
            string query = $@"
            MATCH (s:School {{ name: '{name}' }})
            DETACH DELETE s";

            await neo.ExecuteQueryTruongHocAsync(query);
        }
    }
}
