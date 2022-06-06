using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldDuckCamera.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<Category>> GetAll()
        {
            return await _categoryService.GetAllCategorys();
        }

        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
            return await _categoryService.GetCategory(id);
        }

        [HttpPost]
        public async Task<Category> AddCategory([FromBody] Category category)
        {
            return await _categoryService.AddCategory(category);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategory(id); return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateCategory(int id, [FromBody] Category Object)
        {
            await _categoryService.UpdateCategory(id, Object); return true;
        }
    }
}
