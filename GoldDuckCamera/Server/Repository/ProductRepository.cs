using GoldDuckCamera.Server.AppDbContext;
using GoldDuckCamera.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldDuckCamera.Server.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Product> CreateAsync(Product _object)
        {
            var obj = await _dbContext.Product.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task UpdateAsync(Product _object)
        {
            _dbContext.Product.Update(_object);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Product.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Product.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var data = _dbContext.Product.FirstOrDefault(x => x.id == id);
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
