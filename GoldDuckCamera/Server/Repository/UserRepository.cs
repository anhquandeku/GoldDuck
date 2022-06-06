using GoldDuckCamera.Server.AppDbContext;
using GoldDuckCamera.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GoldDuckCamera.Server.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        ApplicationDbContext _dbContext;
        public readonly ApplicationIdentityDbContext dbContext = new ApplicationIdentityDbContext();
        public readonly IPasswordHasher<Account> passwordHasher = new PasswordHasher<Account>();
        public UserRepository(ApplicationDbContext applicationDbContext, ApplicationIdentityDbContext dbContext, IPasswordHasher<Account> passwordHasher)
        {
            _dbContext = applicationDbContext;
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
        }
        public async Task<User> CreateAsync(User _object)
        {
            Account account = new Account()
            {
                Id = Guid.NewGuid(),
                UserName = _object.username,
                NormalizedUserName = _object.username,
                Email = _object.username + "@gmail.com",
                NormalizedEmail = _object.username + "@gmail.com",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumber = _object.phone,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 10,
            };
            switch (_object.idPermission)
            {
                case 1: account.Permission = "admin";
                    break;
                case 2: account.Permission = "staff";
                    break;
                case 3: account.Permission = "customer";
                    break;
                default: account.Permission = "unknow";
                    break;
            }
            account.PasswordHash = passwordHasher.HashPassword(account, _object.password);
            IdentityUserRole<Guid> identity; 
            await dbContext.Users.AddAsync(account);
            await dbContext.SaveChangesAsync();
            var obj = await _dbContext.User.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task UpdateAsync(User _object)
        {
            _dbContext.User.Update(_object);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<User> GetByIdAsync(string username)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.username == username);
        }

        public async Task DeleteAsync(string username)
        {
            var data = _dbContext.User.FirstOrDefault(x => x.username == username);
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }

        public Task<User> GetUserPassword(string username, string password)
        {
            return _dbContext.User.FirstOrDefaultAsync(x => x.username == username && x.password == password);
        }
    }
}
