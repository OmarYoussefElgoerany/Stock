using StockBLL.Dtos.ItemDto;
using StockBLL.Dtos.StoreDto;
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
        public static Item FromItemDtoToItem(ItemDto itemDto)
        {
            Item item = new Item();

            item.Name= itemDto.Name;
            item.Price= itemDto.Price;
            item.Quantity = itemDto.Quantity;

            return item;
        }
        public static Item FromUpdatedDtotoItem(UpdateItemDto updatedItemDto)
        {
            Item item = new Item();

            item.Id = updatedItemDto.Id;
            item.Name = updatedItemDto.Name;
            item.Price = updatedItemDto.Price;
            item.Quantity = updatedItemDto.Quantity;

            return item;
        }
    }
}
