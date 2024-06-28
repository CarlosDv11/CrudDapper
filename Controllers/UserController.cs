using CrudDapper.Models;
using CrudDapper.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;


namespace CrudDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;
        public UserController(IUserInterface userinterface)
        {
            _userInterface = userinterface;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            IEnumerable<User> users = await _userInterface.GetAllUsers();

            if (!users.Any())
            {
                return NotFound("Nenhum registro localizado!");
            }

            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUserById(int userId)
        {
            User? user = await _userInterface.GetUserById(userId);

            if (user == null)
            {
                return NotFound("Registro não localizado!");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> CreateUser(User user)
        {
            IEnumerable<User> users = await _userInterface.CreateUser(user);
            return Ok(users);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<User>>> UpdateUser(User user)
        {
            User registro = await _userInterface.GetUserById(user.Id);

            if (registro == null) 
            {

                return NotFound("Registro não localizado!");
            }

            IEnumerable<User> users = await _userInterface.UpdateUser(user);

            return Ok(users); 
        }

        [HttpDelete("{userId}")]

        public async Task<ActionResult<IEnumerable<User>>> DeleteUser(int userId)
        {
            User registro = await _userInterface.GetUserById(userId);

            if (registro == null)
            {
                return NotFound("Registro não localizado!");
            }

            IEnumerable<User> users = await _userInterface.DeleteUser(userId);

            return Ok(users);
        }
    }
}
