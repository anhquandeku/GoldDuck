namespace GoldDuckCamera.Server.Repository;
using GoldDuckCamera.Server.AppDbContext;
using GoldDuckCamera.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BrandRepository : IRepository<Brand>
{
    ApplicationDbContext _dbContext;
    public BrandRepository(ApplicationDbContext applicationDbContext)
    {
        _dbContext = applicationDbContext;
    }
    public async Task<Brand> CreateAsync(Brand _object)
    {
        var obj = await _dbContext.Brand.AddAsync(_object);
        _dbContext.SaveChanges();
        return obj.Entity;
    }

    public async Task DeleteAsync(int id)
    {
        var brand = await _dbContext.Brand.FirstOrDefaultAsync(x => x.id == id);
        if (brand != null)
        {
            brand.status = 0;
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<Brand>> GetAllAsync()
    {
        return await _dbContext.Brand.ToListAsync();
    }

    public async Task<Brand> GetByIdAsync(int Id)
    {
        return await _dbContext.Brand.FirstOrDefaultAsync(x => x.id == Id);
    }

    public async Task UpdateAsync(Brand _object)
    {
        _dbContext.Brand.Update(_object);
        await _dbContext.SaveChangesAsync();
    }
}
