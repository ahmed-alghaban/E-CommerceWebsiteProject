using DotNetEnv;
using E_CommerceWebsiteProject.MVC.Abstarction;
using E_CommerceWebsiteProject.MVC.Services;
using E_CommerceWebsiteProject.MVC.Utilities;
using E_CommerceWebsiteProject.src.MVC.Abstarction;
using E_CommerceWebsiteProject.src.MVC.Services;
using ECommerceProject.src.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Env.Load();
var defaultConnection = Environment.GetEnvironmentVariable("DB__CONNECTION")
?? throw new InvalidOperationException("DB Connection Does Not Exist");
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(defaultConnection));
var app = builder.Build();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();