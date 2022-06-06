using GoldDuckCamera.Server.Models;

namespace GoldDuckCamera.Server.Services
{
    public interface ICategoryService
    {
        Task<Category> AddCategory(Category category);

        Task<bool> UpdateCategory(int id, Category category);

        Task<bool> DeleteCategory(int id);

        Task<List<Category>> GetAllCategorys();

        Task<Category> GetCategory(int id);

    }
}
