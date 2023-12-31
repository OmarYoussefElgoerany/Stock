﻿using StockBLL.Dtos.ItemDto;
using StockBLL.Mapping;
using StockDAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBLL.Managers.ItemManager
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
                Price = item.Price,
                Quantity = item.Quantity,
                Name = item.Name
            };
        }

        public int AddItemDto(ItemDto itemDto)
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
      
    }
}