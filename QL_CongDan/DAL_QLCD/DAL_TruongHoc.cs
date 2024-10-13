using DTO_QLCD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLCD
{
    public class DAL_TruongHoc
    {
        string uri = "bolt://localhost:7687";
        string username = "neo4j";
        string password = "12345678";
        string database = "testdb";
        Connection_Neo4J neo;
        public DAL_TruongHoc()
        {
            neo = new Connection_Neo4J(uri, username, password, database);
        }
        public List<DTO_TruongHoc> GetAllSchools()
        {
            // Logic to retrieve all schools from the database
            return new List<DTO_TruongHoc>();
        }

        public void AddSchool(DTO_TruongHoc school)
        {
            // Logic to add a school to the database
        }

        public void UpdateSchool(DTO_TruongHoc school)
        {
            // Logic to update a school in the database
        }

        public void DeleteSchool(string name)
        {
            // Logic to delete a school from the database
        }
    }
}
