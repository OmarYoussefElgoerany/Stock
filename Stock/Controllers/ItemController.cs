using Microsoft.AspNetCore.Mvc;
using StockBLL.Managers.ItemManager;
using StockBLL.Managers.StoreManager;
using StockBLL.ViewModel;

namespace Stock.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemManager itemManager;
        public ItemController(IItemManager itemManager)
        {
            this.itemManager = itemManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetItems(int Id)
        {
            var items = itemManager.GetItemDtoById(Id);
            return Json(items);
        }

        [HttpPost]
        public IActionResult UpdateQuan(StoreDetails storeDetails)
        {
            if (storeDetails == null)
                return RedirectToAction("Index", "Home");

            var itemUpdated = itemManager.UpdatedQuantity(storeDetails);
            return RedirectToAction("Index", "Home");
        }
    }
}
