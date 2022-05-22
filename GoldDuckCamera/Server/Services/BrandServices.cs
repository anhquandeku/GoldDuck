using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Server.Repository;


namespace GoldDuckCamera.Server.Services
{
    public class BrandServices : IBrandService
    {
        private readonly IRepository<Brand> _brand;
        public BrandServices(IRepository<Brand> brand)
        {
            _brand = brand;
        }
        public Task<Brand> AddBrand(Brand brand)
        {
            return _brand.CreateAsync(brand);
        }

        public async Task<bool> DeleteBrand(int id)
        {
            var brand = await _brand.GetByIdAsync(id);
            if (brand != null)
            {
                brand.status = 0;
                await _brand.UpdateAsync(brand);
                return true;
            }
            return false;
        }

        public async Task<List<Brand>> GetAllBrand()
        {
            return await _brand.GetAllAsync();
        }

        public async Task<Brand> GetBrand(int id)
        {
            return await _brand.GetByIdAsync(id);
        }

        public async Task<bool> UpdateBrand(int id, Brand brand)
        {
            
            var getBrand = await _brand.GetByIdAsync(id);
            if (getBrand != null)
            {
                getBrand.name = brand.name;
                await _brand.UpdateAsync(getBrand);
                return true;
            }
            else
                return false;
        }
    }
}
