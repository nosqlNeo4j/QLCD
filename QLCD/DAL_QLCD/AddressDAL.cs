using Neo4j.Driver;
using DTO_QLCD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLCD
{
    public class AddressDAL
    {
        private readonly IDriver _driver;

        public AddressDAL(string uri, string user, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
        }

        public async Task<List<AddressDTO>> GetAllAddressesAsync()
        {
            var query = "MATCH (a:Address) RETURN a.street AS street, a.district AS district, a.city AS city, a.country AS country, a.postal_code AS postalCode";
            var session = _driver.AsyncSession();

            var result = await session.RunAsync(query);
            var addresses = new List<AddressDTO>();

            await result.ForEachAsync(record =>
            {
                addresses.Add(new AddressDTO(
                    record["street"].As<string>(),
                    record["district"].As<string>(),
                    record["city"].As<string>(),
                    record["country"].As<string>(),
                    record["postalCode"].As<string>()
                ));
            });

            await session.CloseAsync();
            return addresses;
        }

        public async Task AddAddressAsync(AddressDTO address)
        {
            var query = "CREATE (a:Address {street: $street, district: $district, city: $city, country: $country, postal_code: $postalCode})";
            var session = _driver.AsyncSession();

            await session.RunAsync(query, new
            {
                street = address.Street,
                district = address.District,
                city = address.City,
                country = address.Country,
                postalCode = address.PostalCode
            });

            await session.CloseAsync();
        }

        public async Task DeleteAddressAsync(string street)
        {
            var query = "MATCH (a:Address {street: $street}) DELETE a";
            var session = _driver.AsyncSession();

            await session.RunAsync(query, new { street });
            await session.CloseAsync();
        }

        public async Task UpdateAddressAsync(string oldStreet, AddressDTO newAddress)
        {
            var query = "MATCH (a:Address {street: $oldStreet}) SET a.street = $street, a.district = $district, a.city = $city, a.country = $country, a.postal_code = $postalCode";
            var session = _driver.AsyncSession();

            await session.RunAsync(query, new
            {
                oldStreet,
                street = newAddress.Street,
                district = newAddress.District,
                city = newAddress.City,
                country = newAddress.Country,
                postalCode = newAddress.PostalCode
            });

            await session.CloseAsync();
        }
    }
}
