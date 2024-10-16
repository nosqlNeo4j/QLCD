using DTO_QLCD;
using Neo4j.Driver;
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
        string uri = "bolt://localhost:7687";
        string username = "neo4j";
        string password = "12345678";
        string database = "testdb";
        Connection_Neo4J neo;
        public DAL_CongDan()
        {
            neo = new Connection_Neo4J(uri, username, password, database);
        }
        public async Task<List<DTO_NguoiDan>> GetAllCitizens()
        {
            var citizens = new List<DTO_NguoiDan>();
            string query = "MATCH (c:Citizen) RETURN c";

            var resultTable = await neo.ExecuteQueryAsync(query);
            foreach (DataRow row in resultTable.Rows)
            {
                var node = row["Node"] as INode;

                if (node != null) // Kiểm tra null trước khi truy cập
                {
                    var citizen = new DTO_NguoiDan
                    {
                        ID = node.Properties.ContainsKey("id") ? node.Properties["id"].ToString() : null,
                        Name = node.Properties.ContainsKey("name") ? node.Properties["name"].ToString() : null,
                        Birthdate = node.Properties.ContainsKey("birthdate") ? Convert.ToDateTime(node.Properties["birthdate"]) : DateTime.MinValue,
                        Gender = node.Properties.ContainsKey("gender") ? node.Properties["gender"].ToString() : null,
                        Phone = node.Properties.ContainsKey("phone") ? node.Properties["phone"].ToString() : null,
                        Email = node.Properties.ContainsKey("email") ? node.Properties["email"].ToString() : null,
                        Nationality = node.Properties.ContainsKey("nationality") ? node.Properties["nationality"].ToString() : null,
                        Occupation = node.Properties.ContainsKey("occupation") ? node.Properties["occupation"].ToString() : null,
                        CCCD = node.Properties.ContainsKey("cccd") ? node.Properties["cccd"].ToString() : null
                    };

                    citizens.Add(citizen);
                }
            }

            return citizens;
        }

        public async Task AddCitizen(DTO_NguoiDan citizen)
        {
            // Logic to add a citizen to the database
            var query = "CREATE (c:Citizen {id: $id, name: $name, birthdate: $birthdate, gender: $gender, phone: $phone, email: $email, nationality: $nationality, occupation: $occupation, cccd: $cccd})";
            await neo.ExecuteQueryAsync(query);
        }

        public async Task UpdateCitizen(DTO_NguoiDan citizen)
        {
            // Logic to update a citizen in the database
            var query = "MATCH (c:Citizen {id: $id}) SET c.name = $name, c.birthdate = $birthdate, c.gender = $gender, c.phone = $phone, c.email = $email, c.nationality = $nationality, c.occupation = $occupation, c.cccd = $cccd";
            await neo.ExecuteQueryAsync(query);
        }

        public async Task DeleteCitizen(string id)
        {
            // Logic to delete a citizen by ID from the database
            var query = "MATCH (c:Citizen {id: $id}) DELETE c";
            await neo.ExecuteQueryAsync(query);
        }
        public void Dispose()
        {
            neo.Dispose();
        }
    }
}
