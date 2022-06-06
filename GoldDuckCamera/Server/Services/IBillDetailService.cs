using GoldDuckCamera.Server.Models;
namespace GoldDuckCamera.Server.Services
{
    public interface IBillDetailService
    {
        Task<BillDetail> AddBillDetail(BillDetail billDetail);

        Task<bool> UpdateBillDetail(int idBill, int idProduct, BillDetail billDetail);

        Task<bool> DeleteBillDetail(int idBill, int idProduct);

        Task<List<BillDetail>> GetAllBillDetail();

        Task<BillDetail> GetBillDetail(int idBill, int idProduct);
    }
}
