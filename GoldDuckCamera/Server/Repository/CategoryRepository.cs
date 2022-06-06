using GoldDuckCamera.Server.AppDbContext;
using GoldDuckCamera.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldDuckCamera.Server.Repository;

public class CategoryRepository : IRepository<Category>
{
    ApplicationDbContext _dbContext;
    public CategoryRepository(ApplicationDbContext applicationDbContext)
    {
        _dbContext = applicationDbContext;
    }

    public async Task<Category> CreateAsync(Category _object)
    {
        var obj = await _dbContext.Category.AddAsync(_object);
        _dbContext.SaveChanges();
        return obj.Entity;
    }

    public async Task UpdateAsync(Category _object)
    {
        _dbContext.Category.Update(_object);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _dbContext.Category.ToListAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _dbContext.Category.FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task DeleteAsync(int id)
    {
        var data = _dbContext.Category.FirstOrDefault(x => x.id == id);
        _dbContext.Remove(data);
        await _dbContext.SaveChangesAsync();
    }
}