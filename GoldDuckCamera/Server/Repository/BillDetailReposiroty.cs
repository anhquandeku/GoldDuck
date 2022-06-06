namespace GoldDuckCamera.Server.Repository;
using GoldDuckCamera.Server.AppDbContext;
using GoldDuckCamera.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BillDetailRepository : IBillDetailRepository<BillDetail>
{
    ApplicationDbContext _dbContext;
    public BillDetailRepository(ApplicationDbContext applicationDbContext)
    {
        _dbContext = applicationDbContext;
    }
    public async Task<BillDetail> CreateAsync(BillDetail _object)
    {
        var obj = await _dbContext.BillDetail.AddAsync(_object);
        _dbContext.SaveChanges();
        return obj.Entity;
    }

    public async Task DeleteAsync(int idBill, int idProduct)
    {
        var billDetail = await _dbContext.BillDetail.FirstOrDefaultAsync(x => x.idBill == idBill && x.idProduct == idProduct);
        _dbContext.Remove(billDetail);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<BillDetail>> GetAllAsync()
    {
        return await _dbContext.BillDetail.ToListAsync();
    }

    public async Task<BillDetail> GetByIdAsync(int idBill, int idPro)
    {
        return await _dbContext.BillDetail.FirstOrDefaultAsync(x => x.idBill == idBill && x.idProduct == idPro);
    }

    public async Task UpdateAsync(BillDetail _object)
    {
        _dbContext.BillDetail.Update(_object);
        await _dbContext.SaveChangesAsync();
    }
}
