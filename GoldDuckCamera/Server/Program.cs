using Blazored.LocalStorage;
using GoldDuckCamera.Server;
using GoldDuckCamera.Server.AppDbContext;
using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Server.Repository;
using GoldDuckCamera.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// For entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<Account, Role>().AddEntityFrameworkStores<ApplicationIdentityDbContext>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtIssuer"],
        ValidAudience = builder.Configuration["JwtAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSecurityKey"]))
    };
});


// For DI registration
builder.Services.AddTransient<IUserRepository<User>, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IRepository<Product>, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<IRepository<Brand>, BrandRepository>();
builder.Services.AddTransient<IBrandService, BrandServices>();


builder.Services.AddTransient<IRepository<Permission>, PermissionRepository>();
builder.Services.AddTransient<IPermissionService, PermissionService>();

builder.Services.AddTransient<IRepository<Category>, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddTransient<IRepository<Bill>, BillRepository>();
builder.Services.AddTransient<IBillService, BillService>();

builder.Services.AddTransient<IBillDetailRepository<BillDetail>, BillDetailRepository>();
builder.Services.AddTransient<IBillDetailService, BillDetailService>();

builder.Services.AddBlazoredLocalStorage();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.UseAuthentication();
app.UseAuthorization();
app.Run();

