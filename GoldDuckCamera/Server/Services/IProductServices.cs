using GoldDuckCamera.Server.Models;

namespace GoldDuckCamera.Server.Services
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product prpduct);

        Task<bool> UpdateProduct(int id, Product product);

        Task<bool> DeleteProduct(int id);

        Task<List<Product>> GetAllProducts();

        Task<Product> GetProduct(int id);

    }
}
