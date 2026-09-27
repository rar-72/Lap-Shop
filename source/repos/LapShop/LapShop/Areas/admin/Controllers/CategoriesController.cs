
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

        public IActionResult Edit(int? categoryId)
        {
            var Category = new TbCategory();
            if (categoryId != null)
            {
                LapShopContext Context = new LapShopContext();
                Category = Context.TbCategories.FirstOrDefault(a => a.CategoryId == categoryId);
            }
            return View(Category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Save(TbCategory category)
        {
            if (!ModelState.IsValid)
                return View("Edit", category);

            LapShopContext Context = new LapShopContext();
            category.ImageName = "";
            if (category.CategoryId == 0)
            {
                category.CreatedBy = "1";
                category.CreatedDate = DateTime.Now;
                Context.TbCategories.Add(category);
            }
            else
            {
                category.UpdatedBy = "1";
                category.UpdatedDate = DateTime.Now;
                Context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }


            Context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
