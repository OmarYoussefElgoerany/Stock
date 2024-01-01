using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Stock.Models;
using StockBLL.Managers.ItemManager;
using StockBLL.Managers.StoreManager;
using StockDAL;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Stock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemManager itemManager;
        private readonly IStoreManager storeManager;
 
        public HomeController(ILogger<HomeController> logger,
            IStoreManager storeManager,
            IItemManager itemManager)
        {
            _logger = logger;
            this.itemManager = itemManager;
            this.storeManager = storeManager;
        }

        public IActionResult Index()
        {
            var stores = storeManager.GetAllStoreDto();
            
            return View(stores);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}