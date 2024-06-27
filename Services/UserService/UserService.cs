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
    }
}
