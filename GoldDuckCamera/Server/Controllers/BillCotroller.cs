using GoldDuckCamera.Server.Services;
using Microsoft.AspNetCore.Mvc;
using GoldDuckCamera.Server.Models;

namespace GoldDuckCamera.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : Controller
    {
        private readonly IBillService _billService;
        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet]
        public async Task<List<Bill>> GetAll()
        {
            return await _billService.GetAllBill();
        }

        [HttpGet("{id}")]
        public async Task<Bill> Get(int id)
        {
            return await _billService.GetBill(id);
        }

        [HttpPost]
        public async Task<Bill> AddUser([FromBody] Bill bill)
        {
            return await _billService.AddBill(bill);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteBill(int id)
        {
            return await _billService.DeleteBill(id);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateBill(int id, [FromBody] Bill bill)
        {
            return await _billService.UpdateBill(id, bill);
        }
    }
}
