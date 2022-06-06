using GoldDuckCamera.Server.Services;
using Microsoft.AspNetCore.Mvc;
using GoldDuckCamera.Server.Models;

namespace GoldDuckCamera.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailController : Controller
    {
        private readonly IBillDetailService _billDetailService;
        public BillDetailController(IBillDetailService billDetailService)
        {
            _billDetailService = billDetailService;
        }

        [HttpGet]
        public async Task<List<BillDetail>> GetAll()
        {
            return await _billDetailService.GetAllBillDetail();
        }

        [HttpGet("{idBill}&&{idProduct}")]
        public async Task<BillDetail> Get(int idBill, int idProduct)
        {
            return await _billDetailService.GetBillDetail(idBill, idProduct);
        }

        [HttpPost]
        public async Task<BillDetail> AddUser([FromBody] BillDetail billDetail)
        {
            return await _billDetailService.AddBillDetail(billDetail);
        }

        [HttpDelete("{idBill}&&{idProduct}")]
        public async Task<bool> DeleteBillDetail(int idBill, int idProduct)
        {
            return await _billDetailService.DeleteBillDetail(idBill, idProduct);
        }

        [HttpPut("{idBill}&&{idProduct}")]
        public async Task<bool> UpdateBillDetail(int idBill, int idProduct, [FromBody] BillDetail billDetail)
        {
            return await _billDetailService.UpdateBillDetail(idBill, idProduct, billDetail);
        }
    }
}
