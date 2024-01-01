using StockBLL.Dtos.ItemDto;
using StockBLL.Managers.ItemManager;
using StockBLL.Mapping;
using StockBLL.ViewModel;
using StockDAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBLL
{
    public class ItemManager : IItemManager
    {
        private readonly IUnitOfWork unitOfWork;
        public ItemManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;       
        }
      

        public List<ItemDto> GetAllItemDto()
        {
            var allItems = unitOfWork.ItemRepo.GetAll();
            if (allItems == null)
                return new List<ItemDto>();

            return allItems.Select(i => new ItemDto
            {
                Name = i.Name,
                Price=i.Price,
                Quantity=i.Quantity,
                StoreId= i.StoreId,
            }).ToList() ;
        }

        public ItemDto GetItemDtoById(int id)
        {
            var item = unitOfWork.ItemRepo.GetById(id);
            if(item == null)
                return null!;

            return new ItemDto
            {
                Id=item.Id,
                Price = item.Price,
                Quantity = item.Quantity,
                Name = item.Name
            };
        }

        public int AddItemDto(AddItemDto itemDto)
        {
            if(itemDto==null)
                return 0 ;
            var item = MappingItemDto.FromItemDtoToItem(itemDto);

            var addedItem = unitOfWork.ItemRepo.Add(item);

            if (addedItem == null)
                return 0;

            unitOfWork.SaveChanges();

            return addedItem.Id;
        }
        public bool IsUpdated(UpdateItemDto updateItemDto)
        {
            if(updateItemDto == null)
                return false;

            var updatedItem = MappingItemDto.FromUpdatedDtotoItem(updateItemDto);

             unitOfWork.ItemRepo.Update(updatedItem);

            unitOfWork.SaveChanges();
            return true;
        }
        public bool IsDeleted(int id)
        {
            if (id == 0)
                return false;

            var item = unitOfWork.ItemRepo.GetById(id);

            if (item == null)
                return false;

            unitOfWork.ItemRepo.Delete(item);

            unitOfWork.SaveChanges();
            return true;
        }

        public bool UpdatedQuantity(StoreDetails storeDetails)
        {
            if (storeDetails == null)
                return false;

            var getItem = unitOfWork.ItemRepo.GetById(storeDetails.item_Id);
            if (getItem == null)
                return false;
            
            getItem.Quantity = storeDetails.Quantity;
            unitOfWork.ItemRepo.Update(getItem);
            unitOfWork.SaveChanges();
            return true;
        }

        public ItemDto GetItemDtoByStoreId(int id)
        {
            var items = unitOfWork.ItemRepo.GetAll();
            var getItemByStore=items.FirstOrDefault(i=>i.StoreId==id);
            if (getItemByStore == null)
                return new ItemDto();
            return new ItemDto
            {
                Id = getItemByStore.Id,
                Name = getItemByStore.Name,
                Price = getItemByStore.Price,
                Quantity = getItemByStore.Quantity
            };
        }
    }
}
