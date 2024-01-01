using StockBLL.Dtos.ItemDto;
using StockBLL;
using StockDAL;
using StockDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBLL.Mapping
{
    public static class MappingItemDto
    {
        public static Item FromItemDtoToItem(AddItemDto itemDto)
        {
            Item item = new Item();

            item.Name= itemDto.Name;
            item.Price= itemDto.Price;
            item.Quantity = itemDto.Quantity;
            item.StoreId = itemDto.StoreId;
            return item;
        }
        public static Item FromUpdatedDtotoItem(UpdateItemDto updatedItemDto)
        {
            Item item = new Item();

            item.Id = updatedItemDto.Id;
            item.Name = updatedItemDto.Name;
            item.Price = updatedItemDto.Price;
            item.Quantity = updatedItemDto.Quantity;
            item.StoreId = updatedItemDto.StoreId;

            return item;
        }
    }
}
