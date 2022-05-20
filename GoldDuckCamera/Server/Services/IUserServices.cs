using GoldDuckCamera.Server.Models;

namespace GoldDuckCamera.Server.Services
{
    public interface IUserService
    {
        Task<User> AddUser(User person);

        Task<bool> UpdateUser(string username, User person);

        Task<bool> DeleteUser(string username);

        Task<List<User>> GetAllUsers();

        Task<User> GetUser(string username);

    }
}
