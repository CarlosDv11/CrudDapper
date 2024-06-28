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

        public Task<IEnumerable<User>> DeleteUser(int Userid)
        {
            throw new NotImplementedException();
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

        public Task<IEnumerable<User>> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
