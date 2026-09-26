using LapShop.Models;
using Microsoft.AspNetCore.Mvc;
namespace LapShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            LapShopContext lap = new LapShopContext();
            var Categories = lap.TbCategories
                .OrderBy(a => a.CategoryId).OrderBy(b => b.CreatedDate).ToList();

            return View(Categories);
        }
    }
}
