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
        public StoreRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
