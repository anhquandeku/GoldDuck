using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldDuckCamera.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<List<Permission>> GetAll()
        {
            return await _permissionService.GetAllPermissions();
        }

        [HttpGet("{id}")]
        public async Task<Permission> Get(int id)
        {
            return await _permissionService.GetPermission(id);
        }

        [HttpPost]
        public async Task<Permission> AddPermission([FromBody] Permission permission)
        {
            return await _permissionService.AddPermission(permission);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeletePermission(int id)
        {
            await _permissionService.DeletePermission(id); return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdatePermission(int id, [FromBody] Permission Object)
        {
            await _permissionService.UpdatePermission(id, Object); return true;
        }
    }
}
