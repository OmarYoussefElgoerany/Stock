using StockBLL.Dtos.ItemDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBLL.Managers.ItemManager
{
    public interface IItemManager
    {
        List<ItemDto> GetAllItemDto();

        ReadItemDto GetItemDtoById(int id);

        int AddItemDto(ItemDto itemDto);

        bool IsUpdated(UpdateItemDto updateItemDto);

        bool IsDeleted(int id);

    }
}
