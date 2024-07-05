using Microsoft.EntityFrameworkCore;
using WebDotNetDB.Models;
using WebDotNetDB.Service;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"].ToString();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<CategoryService, CategoryServiceImpl>();
builder.Services.AddScoped<AccountService, AccountServiceImpl>();
builder.Services.AddScoped<ProductService, ProductServiceImpl>();


builder.Services.AddSession();



var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute(
    name: "myareas",
    pattern: "{area:exists}/{controller}/{action}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");


app.Run();
