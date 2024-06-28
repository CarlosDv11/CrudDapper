using CrudDapper.Models;
using System.Data.SqlClient;

namespace CrudDapper.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly string getConnection;
        public UserService(IConfiguration configuration) 
        { 
            _configuration = configuration;
            getConnection = _configuration.GetConnectionString("DefaultConnection");
        }

        public Task<IEnumerable<User>> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            using (var con = new SqlConnection())
            {

            }
        }

        public Task<User> GetUserById(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
