using GoldDuckCamera.Server.AppDbContext;
using GoldDuckCamera.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldDuckCamera.Server.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<User> CreateAsync(User _object)
        {
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
    }
}
