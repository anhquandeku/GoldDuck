using GoldDuckCamera.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldDuckCamera.Server.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }
        public DbSet<User> User
        {
            get; set;
        }
        public DbSet<Product> Product
        {
            get; set;
        }
        public DbSet<Brand> Brand
        {
            get; set;
        }
        public DbSet<Category> Category
        {
            get; set;
        }

        public DbSet<Permission> Permission
        {
            get; set;
        }
        public DbSet<Bill> Bill
        {
            get; set;
        }
        public DbSet<BillDetail> BillDetail
        {
            get; set;
        }
    }
}