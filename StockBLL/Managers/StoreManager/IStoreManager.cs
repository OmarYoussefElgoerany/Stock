using StockBLL.Dtos;
using StockBLL.Dtos.ItemDto;
using StockBLL.Dtos.StoreDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBLL.Managers.StoreManager
{
    public interface IStoreManager
    {
        List<StoreDto> GetAllStoreDto();

        List<ReadStoreWithItemsDto> GetAllStoreDtoWithItems();
        StoreDto GetStoreDtoById(int id);

        ReadStoreWithItemsDto GetReadStoreDtoWithItemsById(int id);
        int AddStoreDto(AddStoreDto storeDto);

        bool IsUpdated(UpdateStoreDto updateStoreDto);

        bool IsDeleted(int id);
    }
}
