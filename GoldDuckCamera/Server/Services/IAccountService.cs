using GoldDuckCamera.Server.Models;

namespace GoldDuckCamera.Server.Services
{
    public interface IAccountService
    {
        Task addAccount(User user);

        Task<bool> updateAccount(string username, Account account);

        Task<bool> deleteAccount(string username);

        Task<List<Account>> getAllAccount();

        Task<Account> getAccount(string username);
    }
}
