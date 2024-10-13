using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLCD
{
    public class Connection_Neo4J : IDisposable
    {
        private IDriver _driver;
        private IAsyncSession _session;

        public Connection_Neo4J(string uri, string username, string password, string database = "neo4j")
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(username, password));
            _session = _driver.AsyncSession(o => o.WithDatabase(database));
        }

        public async Task<bool> ConnectAsync()
        {
            try
            {
                var result = await _session.RunAsync("RETURN 1");
                await result.FetchAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
                return false;
            }
        }

        public async Task DisconnectAsync()
        {
            await _session.CloseAsync();
            _driver.Dispose();
        }

        public async Task<DataTable> ExecuteQueryAsync(string query)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Node");

            try
            {
                var result = await _session.RunAsync(query);

                while (await result.FetchAsync())
                {
                    var node = result.Current["n"].As<INode>();
                    if (node.Properties.ContainsKey("name"))
                    {
                        dataTable.Rows.Add(node.Properties["name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Query execution failed: {ex.Message}");
            }

            return dataTable;
        }

        public void Dispose()
        {
            _session?.CloseAsync().Wait();
            _driver?.Dispose();
        }
    }
}
