using GoldDuckCamera.Server.Models;
namespace GoldDuckCamera.Server.Services
{
    public interface IBillService
    {
        Task<Bill> AddBill(Bill bill);

        Task<bool> UpdateBill(int id, Bill bill);

        Task<bool> DeleteBill(int id);

        Task<List<Bill>> GetAllBill();

        Task<Bill> GetBill(int id);
    }
}
