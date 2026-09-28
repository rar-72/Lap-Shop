using LapShop.Bl;
using LapShop.Models;
using Microsoft.AspNetCore.Mvc;
namespace LapShop.Areas.admin.Controllers
{
    [Area("admin")]
    public class CategoriesController : Controller
    {

        ClsCategories oclsCategories = new ClsCategories();

        public IActionResult List()
        {

            return View(oclsCategories.GetAll());
        }

        public IActionResult Edit(int? categoryId)
        {
            var Category = new TbCategory();
            if (categoryId != null)
            {
                Category = oclsCategories.GetById(Convert.ToInt32(categoryId));
            }
            return View(Category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Save(TbCategory category, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
                return View("Edit", category);

            category.ImageName = await UploadImage(Files);

            oclsCategories.Save(category);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int categoryId)
        {
            oclsCategories.Delete(categoryId);
            return RedirectToAction("List");
        }

        async Task<string> UploadImage(List<IFormFile> Files)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads/Categories", ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                        return ImageName;
                    }
                }
            }
            return string.Empty;
        }
    }
}
