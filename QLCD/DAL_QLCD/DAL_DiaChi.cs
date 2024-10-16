using DTO_QLCD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLCD
{
    public class DAL_DiaChi
    {
        private readonly string uri = "bolt://localhost:7687";
        private readonly string username = "neo4j";
        private readonly string password = "12345678";
        private readonly string database = "neo4j";
        private readonly Connection_Neo4J neo;
        public DAL_DiaChi()
        {
            neo = new Connection_Neo4J(uri, username, password, database);
        }
        public async Task<List<DTO_DiaChi>> GetAllAddressesAsync()
        {
            List<DTO_DiaChi> addresses = new List<DTO_DiaChi>();
            string query = @"
            MATCH (a:Address)
            RETURN a.street AS Street, a.district AS District, 
            a.city AS City, a.country AS Country, a.postal_code AS PostalCode";

            var resultTable = await neo.ExecuteQueryDiaChiAsync(query);
            foreach (DataRow row in resultTable.Rows)
            {
                DTO_DiaChi address = new DTO_DiaChi
                {
                    Street = row["Street"]?.ToString(),
                    District = row["District"]?.ToString(),
                    City = row["City"]?.ToString(),
                    Country = row["Country"]?.ToString(),
                    PostalCode = row["PostalCode"]?.ToString()
                };
                addresses.Add(address);
            }
            return addresses;
        }


        public void AddAddress(DTO_DiaChi address)
        {
            // Logic to add an address to the database
        }

        public void UpdateAddress(DTO_DiaChi address)
        {
            // Logic to update an address in the database
        }

        public void DeleteAddress(string street)
        {
            // Logic to delete an address from the database
        }
    }
}
