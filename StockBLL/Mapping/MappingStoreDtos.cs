using StockBLL.Dtos.ItemDto;
using StockBLL.Dtos.StoreDto;
using StockDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBLL.Mapping
{
    public static class MappingStoreDtos
    {
        public static Store FromStoreDtoToStore(AddStoreDto storeDto)
        {
            Store store = new Store();
            store.Name = storeDto.Name;
            store.Address = storeDto.Address;
            return store;
        }
        public static Store FromUpdatedDtotoStore(UpdateStoreDto updatedStoreDto)
        {
            Store store = new Store();
            store.Id = updatedStoreDto.Id;
            store.Name = updatedStoreDto.Name;
            store.Address = updatedStoreDto.Address;
            return store;
        }
    }
}
