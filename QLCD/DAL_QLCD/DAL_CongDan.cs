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

        public async Task<List<DTO_NguoiDan>> GetAllCitizens()
        {
            var citizens = new List<DTO_NguoiDan>();
            string query = "MATCH (c:Citizen) RETURN c";

            var resultTable = await neo.ExecuteQueryNguoiDanAsync(query);
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
            await neo.ExecuteQueryNguoiDanAsync(query);
        }

        public async Task UpdateCitizen(DTO_NguoiDan citizen)
        {
            // Logic to update a citizen in the database
            var query = "MATCH (c:Citizen {id: $id}) SET c.name = $name, c.birthdate = $birthdate, c.gender = $gender, c.phone = $phone, c.email = $email, c.nationality = $nationality, c.occupation = $occupation, c.cccd = $cccd";
            await neo.ExecuteQueryNguoiDanAsync(query);
        }

        public async Task DeleteCitizen(string id)
        {
            // Logic to delete a citizen by ID from the database
            var query = "MATCH (c:Citizen {id: $id}) DELETE c";
            await neo.ExecuteQueryNguoiDanAsync(query);
        }
        public void Dispose()
        {
            neo.Dispose();
        }
        public async Task<DTO_NguoiDan> GetCitizenByIdAsync(string id)
        {
            // Thay đổi truy vấn để chèn trực tiếp giá trị của `id`
            string query = $@"
            MATCH (c:Citizen {{id: '{id}'}})
            RETURN c.id AS ID, c.name AS Name, c.birthdate AS Birthdate, 
            c.gender AS Gender, c.phone AS Phone, c.email AS Email,
            c.nationality AS Nationality, c.occupation AS Occupation, c.cccd AS CCCD";

            var resultTable = await neo.ExecuteQueryNguoiDanAsync(query); // Chỉ truyền query mà không có tham số

            if (resultTable.Rows.Count > 0)
            {
                DataRow row = resultTable.Rows[0];
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

                return citizen;
            }

            return null; // Nếu không tìm thấy công dân nào
        }
    }
}
