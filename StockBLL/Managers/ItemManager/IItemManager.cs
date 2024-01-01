using StockBLL.Dtos.ItemDto;
using StockBLL.ViewModel;
using StockDAL.Data.Models;
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

        ItemDto GetItemDtoById(int id);

        int AddItemDto(ItemDto itemDto);
        bool UpdatedQuantity(StoreDetails storeDetails);

        bool IsUpdated(UpdateItemDto updateItemDto);

        bool IsDeleted(int id);

    }
}
