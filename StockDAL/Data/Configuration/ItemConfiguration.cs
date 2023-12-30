using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDAL.Data.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name).
                HasColumnType("varchar(50)").
                HasMaxLength(50).
                IsRequired();

            builder.Property(i=>i.Price).
                IsRequired().
                HasColumnType("decimal(10, 2)");

            builder.Property(i => i.Quantity)
                .IsRequired();

            builder.HasOne(i => i.Store).
                WithMany(i => i.Items).
                HasForeignKey(i => i.StoreId);

            #region SeedingMockData
            builder.HasData(new List<Item>
            {
                new Item
                {
                    Id=1,
                    Name="TV",
                    Price=200,
                    Quantity=50,
                    StoreId=1
                },
                new Item
                {
                   Id=2,
                   Name="Mobile",
                    Price=150,
                    Quantity=100,
                    StoreId=2
                },
                new Item
                {
                   Id=3,
                   Name="Tablet",
                   Price=200,
                   Quantity=50,
                   StoreId=2
                },
                new Item
                {
                    Id=4,
                    Name="Microwave",
                    Price=180,
                    Quantity=30,
                    StoreId=1
                },

            });
            #endregion
        }
    }
}
