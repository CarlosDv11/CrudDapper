using CrudDapper.Models;
namespace CrudDapper.Services.UserService
{
    public interface IUserInterface
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int userid);
        Task<IEnumerable<User>> CreateUser(User user);
        Task<IEnumerable<User>> UpdateUser(User user);
        Task<IEnumerable<User>> DeleteUser(int Userid);
        Task<IEnumerable<UserAddressViewModel>> GetUserWithAddressById(int userId);

    }
}
