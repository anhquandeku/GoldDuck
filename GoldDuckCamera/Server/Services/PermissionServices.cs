using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Server.Repository;

namespace GoldDuckCamera.Server.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IRepository<Permission> _permission;
        public PermissionService(IRepository<Permission> permission)
        {
            _permission = permission;
        }
        public async Task<Permission> AddPermission(Permission permission)
        {
            return await _permission.CreateAsync(permission);
        }

        public async Task<bool> UpdatePermission(int id, Permission permission)
        {
            var data = await _permission.GetByIdAsync(id);

            if (data != null)
            {
                data.name = permission.name;
                await _permission.UpdateAsync(data);
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeletePermission(int id)
        {
            var data = await _permission.GetByIdAsync(id);
            data.status = 0;
            await _permission.UpdateAsync(data);
            return true;
        }

        public async Task<List<Permission>> GetAllPermissions()
        {
            return await _permission.GetAllAsync();
        }

        public async Task<Permission> GetPermission(int id)
        {
            return await _permission.GetByIdAsync(id);
        }
    }
}
