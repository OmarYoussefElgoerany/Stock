using StockBLL.Dtos.ItemDto;
using StockDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBLL
{
    public class ReadStoreWithItemsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public virtual List<ItemDto> Items { get; set; } = new List<ItemDto>();
    }
}
