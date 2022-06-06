using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Server.Repository;


namespace GoldDuckCamera.Server.Services
{
    public class BillDetailService : IBillDetailService
    {
        private readonly IBillDetailRepository<BillDetail> _billDetail;
        public BillDetailService(IBillDetailRepository<BillDetail> billDetail)
        {
            _billDetail = billDetail;
        }
        public Task<BillDetail> AddBillDetail(BillDetail billDetail)
        {
            return _billDetail.CreateAsync(billDetail);
        }

        public async Task<bool> DeleteBillDetail(int idBill, int idProduct)
        {
            await _billDetail.DeleteAsync(idBill, idProduct);
            return true;
        }

        public async Task<List<BillDetail>> GetAllBillDetail()
        {
            return await _billDetail.GetAllAsync();
        }

        public async Task<BillDetail> GetBillDetail(int idBill, int idProduct)
        {
            return await _billDetail.GetByIdAsync(idBill, idProduct);
        }

        public async Task<bool> UpdateBillDetail(int idBill, int idProduct, BillDetail billDetail)
        {

            var getBillDetail = await _billDetail.GetByIdAsync(idBill, idProduct);
            if (getBillDetail != null)
            {
                getBillDetail.count = billDetail.count;
                await _billDetail.UpdateAsync(getBillDetail);
                return true;
            }
            else
                return false;
        }
    }
}
