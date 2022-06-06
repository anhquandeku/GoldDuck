using GoldDuckCamera.Server.Models;

namespace GoldDuckCamera.Server.Services
{
    public interface IPermissionService
    {
        Task<Permission> AddPermission(Permission permission);

        Task<bool> UpdatePermission(int id, Permission permission);

        Task<bool> DeletePermission(int id);

        Task<List<Permission>> GetAllPermissions();

        Task<Permission> GetPermission(int id);

    }
}
