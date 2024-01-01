using StockDAL;
using StockDAL.Repos.StoreRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;
     
        public IStoreRepo StoreRepo { get;}
        public IItemRepo ItemRepo { get; }
        public UnitOfWork(AppDbContext appDbContext,
            IItemRepo itemRepo,
            IStoreRepo storeRepo)
        {
            this.appDbContext = appDbContext;
            this.StoreRepo= storeRepo;
            this.ItemRepo= itemRepo;
        }

        public int SaveChanges() => appDbContext.SaveChanges();
    }
}
