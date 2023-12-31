using StockDAL.Data.Models;
using StockDAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDAL.Repos.ItemRepo
{
    public class ItemRepo : GenericRepo<Item>, IItemRepo
    {
        public ItemRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
