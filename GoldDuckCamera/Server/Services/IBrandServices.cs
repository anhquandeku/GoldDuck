using GoldDuckCamera.Server.Models;
namespace GoldDuckCamera.Server.Services
{
    public interface IBrandService
    {
        Task<Brand> AddBrand(Brand brand);

        Task<bool> UpdateBrand(int id, Brand brand);

        Task<bool> DeleteBrand(int id);

        Task<List<Brand>> GetAllBrand();

        Task<Brand> GetBrand(int id);
    }
}
