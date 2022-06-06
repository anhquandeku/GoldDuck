using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Server.Repository;


namespace GoldDuckCamera.Server.Services
{
    public class BillService : IBillService
    {
        private readonly IRepository<Bill> _bill;
        public BillService(IRepository<Bill> bill)
        {
            _bill = bill;
        }
        public Task<Bill> AddBill(Bill bill)
        {
            return _bill.CreateAsync(bill);
        }

        public async Task<bool> DeleteBill(int id)
        {
            var bill = await _bill.GetByIdAsync(id);
            if (bill != null)
            {
                bill.status = 0;
                await _bill.UpdateAsync(bill);
                return true;
            }
            return false;
        }

        public async Task<List<Bill>> GetAllBill()
        {
            return await _bill.GetAllAsync();
        }

        public async Task<Bill> GetBill(int id)
        {
            return await _bill.GetByIdAsync(id);
        }

        public async Task<bool> UpdateBill(int id, Bill bill)
        {

            var getBill = await _bill.GetByIdAsync(id);
            if (getBill != null)
            {
                getBill.fullname = bill.fullname;
                getBill.date = bill.date;
                getBill.address = bill.address;
                getBill.price = bill.price;
                getBill.username = bill.username;
                getBill.status = bill.status;
                await _bill.UpdateAsync(getBill);
                return true;
            }
            else
                return false;
        }
    }
}
