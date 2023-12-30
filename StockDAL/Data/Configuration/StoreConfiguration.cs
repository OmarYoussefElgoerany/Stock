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
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name).
                 HasColumnType("varchar(50)").
                HasMaxLength(50).
                IsRequired();

            builder.Property(i => i.Address).
                HasColumnType("varchar(100)").
                HasMaxLength(100);

            #region SeedingMockData
            builder.HasData(new List<Store>
            {
                new Store
                {
                    Id=1,
                    Name="Tech Oasis",
                    Address="PO Box 11621"                 
                },
                new Store
                {
                    Id=2,
                    Name="E-Store Express",
                    Address="PO Box 29634"
                },
            });
            #endregion
        }
    }
}
