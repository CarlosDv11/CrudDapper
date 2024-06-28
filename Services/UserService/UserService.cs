using CrudDapper.Models;
using System.Data.SqlClient;
using Dapper;

namespace CrudDapper.Services.UserService
{
    public class UserService : IUserInterface
    {
        private readonly IConfiguration _configuration;
        private readonly string getConnection;
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
            getConnection = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<User>> CreateUser(User user)
        {
            using (var con = new SqlConnection(getConnection)) 
            {
                var sql = "INSERT INTO dbo.Users (Users) values (@Users);";
                await con.ExecuteAsync(sql, user);

                return await con.QueryAsync<User>("select * from Users");
            }
        }

        public async Task<IEnumerable<User>> DeleteUser(int userId)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "delete from dbo.Users where id = @Id";
                await con.ExecuteAsync(sql, new {Id =  userId});

                return await con.QueryAsync<User>("select * from Users");
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "SELECT * FROM dbo.Users";
                return await con.QueryAsync<User>(sql);
            }
        }

        public async Task<User?> GetUserById(int Userid)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "SELECT * FROM dbo.Users where id = @Id";
                return await con.QueryFirstOrDefaultAsync<User>(sql, new { Id = Userid });
                
            }
        }

        public async Task<IEnumerable<User>> UpdateUser(User user)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "update dbo.Users set Users = @Users where Id = @Id";
                await con.ExecuteAsync(sql, user);

                return await con.QueryAsync<User>("SELECT * FROM dbo.Users");
            }
        }
    }
}
