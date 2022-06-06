using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldDuckCamera.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Product>> GetAll()
        {
            return await _productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _productService.GetProduct(id);
        }

        [HttpPost]
        public async Task<Product> AddProduct([FromBody] Product product)
        {
            return await _productService.AddProduct(product);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id); return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateProduct(int id, [FromBody] Product Object)
        {
            await _productService.UpdateProduct(id, Object); return true;
        }
    }
}
