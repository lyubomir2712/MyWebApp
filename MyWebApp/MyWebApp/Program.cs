using Contracts.CRUDContracts;
using Contracts.CRUDContracts.Delete;
using Contracts.CRUDContracts.Update;
using Data.Data;
using Data.Repository;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyWebApp.Data.Contracts.CRUDcontracts;
using MyWebApp.Data.Implementation.CRUD;
using MyWebApp.Data.Implementation.CRUD.Create;
using MyWebApp.Data.Implementation.CRUD.Delete;
using MyWebApp.Data.Implementation.CRUD.Read;
using MyWebApp.Data.Implementation.CRUD.Update;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

Env.Load();
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;
//CRUD
builder.Services.AddScoped<IReadCategoriesService, ReadCategoriesService>();
builder.Services.AddScoped<ICreateCategoryService, CreateCategoryService>();
builder.Services.AddScoped<IGetUpdateCategoryService, GetUpdateCategoryService>();
builder.Services.AddScoped<IPostUpdateCategoryService, PostUpdateCategoryService>();
builder.Services.AddScoped<IGetDeleteCategoryService, GetDeleteCategoryService>();
builder.Services.AddScoped<IPostDeleteCategoryService, PostDeleteCategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();