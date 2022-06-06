namespace GoldDuckCamera.Server.Repository;
using GoldDuckCamera.Server.AppDbContext;
using GoldDuckCamera.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BillRepository : IRepository<Bill>
{
    ApplicationDbContext _dbContext;
    public BillRepository(ApplicationDbContext applicationDbContext)
    {
        _dbContext = applicationDbContext;
    }
    public async Task<Bill> CreateAsync(Bill _object)
    {
        var obj = await _dbContext.Bill.AddAsync(_object);
        _dbContext.SaveChanges();
        return obj.Entity;
    }

    public async Task DeleteAsync(int id)
    {
        var bill = await _dbContext.Bill.FirstOrDefaultAsync(x => x.id == id);
        if (bill != null)
        {
            bill.status = 0;
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<Bill>> GetAllAsync()
    {
        return await _dbContext.Bill.ToListAsync();
    }

    public async Task<Bill> GetByIdAsync(int Id)
    {
        return await _dbContext.Bill.FirstOrDefaultAsync(x => x.id == Id);
    }

    public async Task UpdateAsync(Bill _object)
    {
        _dbContext.Bill.Update(_object);
        await _dbContext.SaveChangesAsync();
    }
}
