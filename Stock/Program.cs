using Microsoft.EntityFrameworkCore;
using StockBLL.Managers.ItemManager;
using StockBLL.Managers.StoreManager;
using StockDAL;
using StockDAL.Data.Models;
using StockDAL.Repos.ItemRepo;
using StockDAL.Repos.StoreRepo;
using StockDAL.UnitOfWork;

namespace Stock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region DataBase
            var connectionString = builder.Configuration.GetConnectionString("Stock");
            builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(connectionString));
            #endregion

            #region Managers
            builder.Services.AddScoped<IItemManager, ItemManager>();
            builder.Services.AddScoped<IStoreManager, StoreManager>();
            #endregion

            #region Repos
            builder.Services.AddScoped<IStoreRepo, StoreRepo>();
            builder.Services.AddScoped<IItemRepo,ItemRepo>();
            #endregion

            #region UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
        }
    }
}