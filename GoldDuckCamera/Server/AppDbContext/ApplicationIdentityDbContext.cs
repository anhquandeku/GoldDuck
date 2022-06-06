using GoldDuckCamera.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoldDuckCamera.Server.AppDbContext
{
    public class ApplicationIdentityDbContext : IdentityDbContext<Account, Role, Guid>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {

        }
        public ApplicationIdentityDbContext()
        {
        }


    }
}
