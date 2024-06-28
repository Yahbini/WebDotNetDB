using Microsoft.EntityFrameworkCore;
using WebDotNetDB.Models;
using WebDotNetDB.Service;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("ConnectionStrings:DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<CategoryService, CategoryServiceImpl>();
builder.Services.AddScoped<AccountService, AccountServiceImpl>();



var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "myareas",
    pattern: "{area:exists}/{controller}/{action}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");


app.Run();
