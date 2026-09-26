using LapShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Areas.admin.Controllers
{
    [Area("admin")]
    public class CategoriesController : Controller
    {


        public IActionResult List()
        {
            LapShopContext Context = new LapShopContext();
            var listCategories = Context.TbCategories.ToList();
            return View(listCategories);
        }

        public IActionResult Edit()
        {
            return View(new TbCategory());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Save(TbCategory category)
        {
            return View("Edit");
        }
    }
}
