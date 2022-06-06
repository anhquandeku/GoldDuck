using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Server.Repository;

namespace GoldDuckCamera.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _product;
        public ProductService(IRepository<Product> product)
        {
            _product = product;
        }
        public async Task<Product> AddProduct(Product product)
        {
            return await _product.CreateAsync(product);
        }

        public async Task<bool> UpdateProduct(int id, Product product)
        {
            var data = await _product.GetByIdAsync(id);

            if (data != null)
            {
                data.img1 = product.img1;
                data.img2 = product.img2;
                data.idCategory = product.idCategory;
                data.price = product.price;
                data.name = product.name;
                data.cost = product.cost;
                data.idBrand = product.idBrand;
                data.date = product.date;
                data.count = product.count;
                data.sold = product.sold;
                data.sale = product.sale;
                data.guarantee = product.guarantee;
                data.specifications = product.specifications;

                await _product.UpdateAsync(data);
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var data = await _product.GetByIdAsync(id);
            data.status = 0;
            await _product.UpdateAsync(data);
            return true;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _product.GetAllAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _product.GetByIdAsync(id);
        }
    }
}
