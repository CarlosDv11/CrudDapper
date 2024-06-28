using CrudDapper.Models;
namespace CrudDapper.Services.UserService
{
    public interface IUserInterface
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetById(int Userid);
        Task<IEnumerable<User>> CreateUser(User user);
        Task<IEnumerable<User>> UpdateLivro(User user);
        Task<IEnumerable<User>> DeleteUser(int Userid);
    }
}
