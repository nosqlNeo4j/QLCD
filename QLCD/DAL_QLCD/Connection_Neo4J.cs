using Neo4j.Driver;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DAL_QLCD
{
    public class Connection_Neo4J : IDisposable
    {
        private readonly IDriver _driver;
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
                await result.SingleAsync();
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
            if (_session != null)
            {
                await _session.CloseAsync();
            }
            _driver?.Dispose();
        }

        public async Task<DataTable> ExecuteQueryAsync(string query)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("StartDate");
            dataTable.Columns.Add("EndDate");
            dataTable.Columns.Add("Degree");

            try
            {
                var result = await _session.RunAsync(query);
                var records = await result.ToListAsync();

                foreach (var record in records)
                {
                    if (record.ContainsKey("Name") && record.ContainsKey("StartDate") &&
                        record.ContainsKey("EndDate") && record.ContainsKey("Degree"))
                    {
                        string name = record["Name"].As<string>();
                        DateTime startDate = record["StartDate"].As<DateTime>();
                        DateTime endDate = record["EndDate"].As<DateTime>();
                        string degree = record["Degree"].As<string>();

                        dataTable.Rows.Add(name, startDate, endDate, degree);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Query execution failed: {ex.Message}");
            }

            return dataTable;
        }

        public async Task<DataTable> ExecuteQueryNguoiDanAsync(string query)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Birthdate");
            dataTable.Columns.Add("Gender");
            dataTable.Columns.Add("Phone");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Nationality");
            dataTable.Columns.Add("Occupation");
            dataTable.Columns.Add("CCCD");

            try
            {
                var result = await _session.RunAsync(query);
                var records = await result.ToListAsync();

                foreach (var record in records)
                {
                    dataTable.Rows.Add(
                        record["ID"].As<string>(),
                        record["Name"].As<string>(),
                        record["Birthdate"].As<DateTime>(),
                        record["Gender"].As<string>(),
                        record["Phone"].As<string>(),
                        record["Email"].As<string>(),
                        record["Nationality"].As<string>(),
                        record["Occupation"].As<string>(),
                        record["CCCD"].As<string>()
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Query execution for NguoiDan failed: {ex.Message}");
            }

            return dataTable;
        }

        public async Task<DataTable> ExecuteQueryCongViecAsync(string query)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Company");
            dataTable.Columns.Add("Position");
            dataTable.Columns.Add("StartDate");
            dataTable.Columns.Add("Salary");

            try
            {
                var result = await _session.RunAsync(query);
                var records = await result.ToListAsync();

                foreach (var record in records)
                {
                    dataTable.Rows.Add(
                        record["Company"].As<string>(),
                        record["Position"].As<string>(),
                        record["StartDate"].As<DateTime>(),
                        record["Salary"].As<decimal>()
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Query execution for CongViec failed: {ex.Message}");
            }

            return dataTable;
        }

        public async Task<DataTable> ExecuteQueryDiaChiAsync(string query)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Street");
            dataTable.Columns.Add("District");
            dataTable.Columns.Add("City");
            dataTable.Columns.Add("Country");
            dataTable.Columns.Add("PostalCode");

            try
            {
                var result = await _session.RunAsync(query);
                var records = await result.ToListAsync();

                foreach (var record in records)
                {
                    dataTable.Rows.Add(
                        record["Street"].As<string>(),
                        record["District"].As<string>(),
                        record["City"].As<string>(),
                        record["Country"].As<string>(),
                        record["PostalCode"].As<string>()
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Query execution for DiaChi failed: {ex.Message}");
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
