using Dapper;
using LiveMedTest.Dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace LiveMedTest.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;
        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(User entity)
        {
            var sql = "Insert into user (id_user,user,id_country) VALUES (@id_user,@user,@id_country)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM user WHERE id_user = @id_user";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var sql = "SELECT * FROM user";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<User>(sql);
                return result.ToList();
            }
        }
        public async Task<User> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM user WHERE id_user = @id_user";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IEnumerable<UserCountry>> GetUserCountries()
        {
            var sql = "[GetUserCountries]";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();


                var result = connection.Query<dynamic>(sql, commandType: System.Data.CommandType.StoredProcedure)
                                 .Select(item => new UserCountry()
                                 {
                                     Name = item.user,
                                     Country = item.country
                                 });

                return result;
            }
        }

        public async Task<int> UpdateAsync(User entity)
        {
            var sql = "UPDATE user SET user = @user, id_country = @id_country  WHERE id_user = @id_user";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
