using DTO_QLCD;
using System;
using System.Collections.Generic;
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
        public List<DTO_CongViec> GetAllJobs()
        {
            // Logic to retrieve all jobs from the database
            return new List<DTO_CongViec>();
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
