using GoldDuckCamera.Server.Models;

namespace GoldDuckCamera.Server.Services
{
    public interface IUserService
    {
        Task<User> AddUser(User user);

        Task<bool> UpdateUser(string username, User user);

        Task<bool> DeleteUser(string username);

        Task<List<User>> GetAllUsers();

        Task<User> GetUser(string username);
        Task<User> GetUserPassword(string username, string password);

    }
}
