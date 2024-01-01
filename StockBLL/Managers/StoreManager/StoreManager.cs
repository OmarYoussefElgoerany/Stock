using Microsoft.IdentityModel.Tokens;
using StockBLL.Dtos;
using StockBLL.Dtos.ItemDto;
using StockBLL.Dtos.StoreDto;
using StockBLL.Mapping;
using StockDAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBLL.Managers.StoreManager
{
    public class StoreManager : IStoreManager
    {
        private readonly IUnitOfWork unitOfWork;
        public StoreManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<StoreDto> GetAllStoreDto()
        {
            var allStores = unitOfWork.StoreRepo.GetAll();

            if (allStores == null)
                return new List<StoreDto>();

            return allStores.Select(i => new StoreDto
            {
                Id=i.Id,
                Address = i.Address,
                Name = i.Name
            }).ToList();

        }


        public List<ReadStoreWithItemsDto> GetAllStoreDtoWithItems()
        {
            var allStores = unitOfWork.StoreRepo.GetStoresIncludeAllItems();

            if (allStores == null)
                return new List<ReadStoreWithItemsDto>();

            return allStores.Select(i => new ReadStoreWithItemsDto
            {
                Address = i.Address,
                Name = i.Name,
                Items=i.Items.Select(i=> new ItemDto
                {
                    Id=i.Id,
                    Name=i.Name,
                    Price=i.Price,
                    Quantity=i.Quantity
                }).ToList()
            }).ToList();

        }
        public ReadStoreWithItemsDto GetReadStoreDtoWithItemsById(int id)
        {
            var getAllStores = unitOfWork.StoreRepo.GetStoresIncludeAllItems();
            var getStore = getAllStores.FirstOrDefault(i => i.Id == id);
            if (getStore == null)
                return null!;

            return new ReadStoreWithItemsDto
            {
                Name = getStore.Name,
                Address = getStore.Address,
                Items = getStore.Items.Select(i=> new ItemDto
                {
                    Id= i.Id,
                    Name =i.Name,
                    Price=i.Price,
                }).ToList(),
            };
        }

        public StoreDto GetStoreDtoById(int id)
        {
            var store = unitOfWork.StoreRepo.GetById(id);
            if (store == null)
                return null!;

            return new StoreDto
            {
                Id=store.Id,
                Name=store.Name,
                Address=store.Address,
            };
        }
        public int AddStoreDto(AddStoreDto storeDto)
        {
            if(storeDto == null)
                return 0;
            var store = MappingStoreDtos.FromStoreDtoToStore(storeDto);
            var addedStore = unitOfWork.StoreRepo.Add(store);
            if (addedStore == null)
                return 0;
            unitOfWork.SaveChanges();

            return addedStore.Id;
        }

        public bool IsUpdated(UpdateStoreDto updateStoreDto)
        {
            if (updateStoreDto == null) 
                return false;

            var updatedStore = MappingStoreDtos.FromUpdatedDtotoStore(updateStoreDto);

            var store = unitOfWork.StoreRepo.Update(updatedStore);

            unitOfWork.SaveChanges();

            return true;
        }

        public bool IsDeleted(int id)
        {
            if (id == 0) 
                return false;

            var store = unitOfWork.StoreRepo.GetById(id);

            if (store == null) 
                return false;

            unitOfWork.StoreRepo.Delete(store);
            unitOfWork.SaveChanges();
            return true;
        }

    }
}
