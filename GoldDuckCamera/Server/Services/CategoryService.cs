using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Server.Repository;

namespace GoldDuckCamera.Server.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _category;
        public CategoryService(IRepository<Category> category)
        {
            _category = category;
        }
        public async Task<Category> AddCategory(Category category)
        {
            return await _category.CreateAsync(category);
        }

        public async Task<bool> UpdateCategory(int id, Category category)
        {
            var data = await _category.GetByIdAsync(id);

            if (data != null)
            {
                data.name = category.name;
                await _category.UpdateAsync(data);
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var data = await _category.GetByIdAsync(id);
            data.status = 0;
            await _category.UpdateAsync(data);
            return true;
        }

        public async Task<List<Category>> GetAllCategorys()
        {
            return await _category.GetAllAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _category.GetByIdAsync(id);
        }
    }
}
