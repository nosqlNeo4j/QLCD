using Neo4j.Driver;
using DTO_QLCD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLCD
{
    public class RelationshipDAL
    {
        private readonly IDriver _driver;

        public RelationshipDAL(string uri, string user, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
        }

        public async Task<List<RelationshipDTO>> GetAllRelationshipsAsync()
        {
            var query = "MATCH (a)-[r]->(b) RETURN a, r, b";
            var session = _driver.AsyncSession();
            var result = await session.RunAsync(query);
            var relationships = new List<RelationshipDTO>();

            await result.ForEachAsync(record =>
            {
                try
                {
                    if (record.ContainsKey("a") && record.ContainsKey("r") && record.ContainsKey("b"))
                    {
                        var entityA = GetEntityName(record["a"]);
                        var relationshipType = record["r"].As<IRelationship>().Type;
                        var entityB = GetEntityName(record["b"]);

                        relationships.Add(new RelationshipDTO(entityA, relationshipType, entityB));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing record: {ex.Message}");
                }
            });

            await session.CloseAsync();
            return relationships;
        }

        private string GetEntityName(object nodeObj)
        {
            if (nodeObj is INode node)
            {
                if (node.Properties.ContainsKey("name"))
                {
                    return node.Properties["name"].As<string>();
                }
                else if (node.Properties.ContainsKey("street"))
                {
                    return node.Properties["street"].As<string>();
                }
                else if (node.Properties.ContainsKey("company"))
                {
                    return node.Properties["company"].As<string>();
                }
            }

            return "Unknown";
        }

        public async Task<List<string>> GetFilteredEntitiesAsync(string entityType)
        {
            string query;

            if (entityType == "Address")
            {
                query = "MATCH (n:Address) RETURN n.street AS name";
            }
            else if (entityType == "Job")
            {
                query = "MATCH (n:Job) RETURN n.company AS name";
            }
            else if (entityType == "Citizen")
            {
                query = "MATCH (n:Citizen) RETURN n.name AS name";
            }
            else if (entityType == "School")
            {
                query = "MATCH (n:School) RETURN n.name AS name";
            }
            else
            {
                return new List<string>();
            }

            var session = _driver.AsyncSession();
            var result = await session.RunAsync(query);
            var entities = new List<string>();

            await result.ForEachAsync(record =>
            {
                try
                {
                    if (record.ContainsKey("name"))
                    {
                        entities.Add(record["name"].As<string>());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing record: {ex.Message}");
                }
            });

            await session.CloseAsync();
            return entities;
        }

        public async Task AddRelationshipAsync(string entityA, string relationshipType, string entityB)
        {
            var query = $"MATCH (a {{name: '{entityA}'}}), (b {{name: '{entityB}'}}) CREATE (a)-[:{relationshipType}]->(b)";
            var session = _driver.AsyncSession();
            await session.RunAsync(query);
            await session.CloseAsync();
        }
        public async Task DeleteRelationshipAsync(string entityA, string relationshipType, string entityB)
        {
            var query = $"MATCH (a {{name: '{entityA}'}})-[r:{relationshipType}]->(b {{name: '{entityB}'}}) DELETE r";
            var session = _driver.AsyncSession();
            await session.RunAsync(query);
            await session.CloseAsync();
        }
    }
}
