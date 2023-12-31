using Microsoft.AspNetCore.Mvc;
using StockBLL;
using StockBLL.Managers.ItemManager;
using StockBLL.Managers.StoreManager;

namespace Stock.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreManager storeManager;
        public StoreController( IStoreManager storeManager)
        {
            this.storeManager = storeManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(StoreDto storeDto)
        {
            if (!ModelState.IsValid)
                return View("Create");
            storeManager.AddStoreDto(storeDto);
            return RedirectToAction("Index","Home");
        }
    }
}
