using Microsoft.EntityFrameworkCore;
using StockDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockDAL
{
    public class AppDbContext:DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }

        public AppDbContext()
        {}
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
