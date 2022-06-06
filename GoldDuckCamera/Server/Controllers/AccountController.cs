using GoldDuckCamera.Server.AppDbContext;
using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GoldDuckCamera.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController: Controller
    {
        public readonly ApplicationIdentityDbContext dbContext = new ApplicationIdentityDbContext();
        public readonly IPasswordHasher<Account> passwordHasher = new PasswordHasher<Account>();
        public readonly UserManager<Account> userManager;
        public AccountController(ApplicationIdentityDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }
        [HttpPost("{id}")]
        public async Task<bool> addAccount(UserViewModel user)
        {
            Account account = new Account()
            {
                Id = Guid.NewGuid(),
                UserName = user.username,
                NormalizedUserName = user.username,
                Email = user.username + "@gmail.com",
                NormalizedEmail = user.username + "@gmail.com",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumber = user.phone,
                TwoFactorEnabled = false, 
                LockoutEnabled = false, 
                AccessFailedCount = 10
            };
            account.PasswordHash = passwordHasher.HashPassword(account, user.phone);
            await dbContext.Users.AddAsync(account);
            await dbContext.SaveChangesAsync();
            return true;
         
        }

    }
}
