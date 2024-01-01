using Microsoft.AspNetCore.Mvc;
using StockBLL;
using StockBLL.Managers.ItemManager;
using StockBLL.Managers.StoreManager;

namespace Stock.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreManager storeManager;
        private readonly IItemManager itemManger;

        public StoreController( IStoreManager storeManager,IItemManager itemManager)
        {
            this.storeManager = storeManager;
            this.itemManger = itemManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var store =storeManager.GetReadStoreDtoWithItemsById(id);
            ViewBag.stores = store.Items; 
            return View(store);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(AddStoreDto storeDto)
        {
            if (!ModelState.IsValid)
                return View();
            storeManager.AddStoreDto(storeDto);
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var store = storeManager.GetStoreDtoById(id);
            return View(store);
        }
        [HttpPost]
        public IActionResult Edit(UpdateStoreDto updateStoreDto)
        {
            if (!ModelState.IsValid)
                return View();
            var isUpdated= storeManager.IsUpdated(updateStoreDto);
            if(isUpdated == false)
                return View();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var store = storeManager.GetStoreDtoById(id);
            return View(store);
        }
        [HttpPost]
        public IActionResult Delete(StoreDto storeDto)
        {
            if (!ModelState.IsValid)
                return View();
            var isDeleted = storeManager.IsDeleted(storeDto.Id);
            if (isDeleted == false)
                return View();
            return RedirectToAction("Index", "Home");
        }
     
    }
}
