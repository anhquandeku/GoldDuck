using GoldDuckCamera.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldDuckCamera.Server.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
    }
}