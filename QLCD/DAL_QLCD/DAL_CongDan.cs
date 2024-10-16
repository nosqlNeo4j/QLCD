using DTO_QLCD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLCD
{
    public class DAL_CongDan
    {
        private readonly string uri = "bolt://localhost:7687";
        private readonly string username = "neo4j";
        private readonly string password = "12345678";
        private readonly string database = "neo4j";
        private readonly Connection_Neo4J neo;
        public DAL_CongDan()
        {
            neo = new Connection_Neo4J(uri, username, password, database);
        }
        public async Task<List<DTO_NguoiDan>> GetAllCitizensAsync()
        {
            List<DTO_NguoiDan> citizens = new List<DTO_NguoiDan>();
            string query = @"
            MATCH (c:Citizen)
            RETURN c.id AS ID, c.name AS Name, c.birthdate AS Birthdate, 
            c.gender AS Gender, c.phone AS Phone, c.email AS Email,
            c.nationality AS Nationality, c.occupation AS Occupation, c.cccd AS CCCD";

            var resultTable = await neo.ExecuteQueryNguoiDanAsync(query);
            foreach (DataRow row in resultTable.Rows)
            {
                DTO_NguoiDan citizen = new DTO_NguoiDan
                {
                    ID = row["ID"]?.ToString(),
                    Name = row["Name"]?.ToString(),
                    Birthdate = DateTime.TryParse(row["Birthdate"]?.ToString(), out var birthdate) ? birthdate : DateTime.MinValue,
                    Gender = row["Gender"]?.ToString(),
                    Phone = row["Phone"]?.ToString(),
                    Email = row["Email"]?.ToString(),
                    Nationality = row["Nationality"]?.ToString(),
                    Occupation = row["Occupation"]?.ToString(),
                    CCCD = row["CCCD"]?.ToString()
                };
                citizens.Add(citizen);
            }
            return citizens;
        }

        public void AddCitizen(DTO_NguoiDan citizen)
        {
            // Logic to add a citizen to the database
        }

        public void UpdateCitizen(DTO_NguoiDan citizen)
        {
            // Logic to update a citizen in the database
        }

        public void DeleteCitizen(string id)
        {
            // Logic to delete a citizen by ID from the database
        }
    }
}
