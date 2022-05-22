using GoldDuckCamera.Server.Services;
using Microsoft.AspNetCore.Mvc;
using GoldDuckCamera.Server.Models;

namespace GoldDuckCamera.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<List<Brand>> GetAll()
        {
            return await _brandService.GetAllBrand();
        }

        [HttpGet("{id}")]
        public async Task<Brand> Get(int id)
        {
            return await _brandService.GetBrand(id);
        }

        [HttpPost]
        public async Task<Brand> AddUser([FromBody] Brand brand)
        {
            return await _brandService.AddBrand(brand);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteBrand(int id)
        {
            return await _brandService.DeleteBrand(id);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateBrand(int id, [FromBody] Brand brand)
        {
            return await _brandService.UpdateBrand(id, brand);
        }
    }
}
