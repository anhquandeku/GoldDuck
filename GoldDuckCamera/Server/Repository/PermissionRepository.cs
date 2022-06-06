using GoldDuckCamera.Server.AppDbContext;
using GoldDuckCamera.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldDuckCamera.Server.Repository
{
    public class PermissionRepository : IRepository<Permission>
    {
        ApplicationDbContext _dbContext;
        public PermissionRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Permission> CreateAsync(Permission _object)
        {
            var obj = await _dbContext.Permission.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task UpdateAsync(Permission _object)
        {
            _dbContext.Permission.Update(_object);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Permission>> GetAllAsync()
        {
            return await _dbContext.Permission.ToListAsync();
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            return await _dbContext.Permission.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var data = _dbContext.Permission.FirstOrDefault(x => x.id == id);
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
