using Microsoft.EntityFrameworkCore;
using StockDAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDAL.Repos.StoreRepo
{
    public class StoreRepo : GenericRepo<Store>, IStoreRepo
    {
        private readonly AppDbContext appDbContext;

        public StoreRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }
       
        public List<Store> GetStoresIncludeAllItems()
        {
            return appDbContext.Stores.Include(i=>i.Items).ToList();
        }
    }
}
