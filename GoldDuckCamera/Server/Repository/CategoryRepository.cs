using GoldDuckCamera.Server.AppDbContext;
using GoldDuckCamera.Server.Models;

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

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Category _object)
    {
        throw new NotImplementedException();
    }
}