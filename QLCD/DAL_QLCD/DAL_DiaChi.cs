using DTO_QLCD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLCD
{
    public class DAL_DiaChi
    {
        string uri = "bolt://localhost:7687";
        string username = "neo4j";
        string password = "12345678";
        string database = "testdb";
        Connection_Neo4J neo;
        public DAL_DiaChi()
        {
            neo = new Connection_Neo4J(uri, username, password, database);
        }
        public List<DTO_DiaChi> GetAllAddresses()
        {
            // Logic to retrieve all addresses from the database
            return new List<DTO_DiaChi>();
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
