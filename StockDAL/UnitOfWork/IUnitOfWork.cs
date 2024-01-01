using StockDAL;
using StockDAL.Repos.StoreRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IStoreRepo StoreRepo  { get; }
        public IItemRepo  ItemRepo { get; }

        int SaveChanges();
    }
}
