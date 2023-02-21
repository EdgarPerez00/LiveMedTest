using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedTest.Repository
{
    public  class CountryRepository : ICountryRepository
    {
        private readonly IConfiguration configuration;
        public CountryRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Country entity)
        {
            var sql = "Insert into Country (id_country,country) VALUES (@id_country,@country)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM country WHERE id_country = @id_country";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }
        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            var sql = "SELECT * FROM Country";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Country>(sql);
                return result.ToList();
            }
        }
        public async Task<Country> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM country WHERE id_country = @id_country";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Country>(sql, new { Id = id });
                return result;
            }
        }
        public async Task<int> UpdateAsync(Country entity)
        {
            var sql = "UPDATE country SET country = @country WHERE id_country = @id_country";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}

