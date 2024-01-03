using Microsoft.AspNetCore.Mvc;
using StockBLL;
using StockBLL.Dtos.ItemDto;
using StockBLL.Managers.ItemManager;
using StockBLL.Managers.StoreManager;
using StockBLL.ViewModel;
using StockDAL;
using StockDAL.Data.Models;

namespace Stock.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemManager itemManager;
        private readonly IStoreManager storeManager;

        public ItemController(IItemManager itemManager,IStoreManager storeManager)
        {
            this.itemManager = itemManager;
            this.storeManager = storeManager;
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var itemsInStore = storeManager.GetStoreIdWithAllItems(id);

            ViewBag.StoreId = id;

            return View(itemsInStore);
        }
        [HttpGet]
        public IActionResult GetItems(int Id)
        {
            var items = itemManager.GetItemDtoByStoreId(Id);
            return Json(items);
        }
        [HttpGet]
        public IActionResult GetItemsDetials(int Id)
        {
            var items = itemManager.GetItemDtoById(Id);
            return Json(items);
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.StoreId = id;
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddItemDto item)
        {
            if(!ModelState.IsValid)
                return RedirectToAction("Create");

            var newItem =itemManager.AddItemDto(item);
            return RedirectToAction("Details","Item", new { id = item.StoreId });
        }
        [HttpGet]
        public IActionResult Edit(int id,int storeId)
        {
            var item = itemManager.GetItemDtoById(id);
            ViewBag.StoreId = storeId;
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(UpdateItemDto item)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit");
       
            itemManager.IsUpdated(item);

            return RedirectToAction("Details", "Item", new { id = item.Id });
        }
    

        [HttpPost]
        public IActionResult UpdateQuan(StoreDetails storeDetails)
        {
            if (storeDetails == null)
                return RedirectToAction("Index", "Home");

            var itemUpdated = itemManager.UpdatedQuantity(storeDetails);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Delete(int id,int storeId)
        {
            var item = itemManager.GetItemDtoById(id);
            ViewBag.StoreId = storeId;
            return View(item);
        }
        [HttpPost]
        public IActionResult Delete(ItemDto item)
        {
            if (!ModelState.IsValid)
                return View();
            var isDeleted = itemManager.IsDeleted(item.Id);
            if (isDeleted == false)
                return View();
            return RedirectToAction("Details", "Item", new { id = item.StoreId });
        }
    }
}
