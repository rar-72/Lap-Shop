using LapShop.Models;

namespace LapShop.Bl
{
    public class ClsCategories
    {
        LapShopContext Context = new LapShopContext();
        public List<TbCategory> GetAll()
        {
            try
            {

                var listCategories = Context.TbCategories.ToList();
                return listCategories;
            }
            catch
            {
                return new List<TbCategory>();
            }
        }

        public TbCategory GetById(int id)
        {
            try
            {
                LapShopContext Context = new LapShopContext();
                var Category = Context.TbCategories.FirstOrDefault(a => a.CategoryId == id);
                return Category;
            }
            catch
            {
                return new TbCategory();
            }
        }

        public bool Save(TbCategory category)
        {
            try
            {
                LapShopContext Context = new LapShopContext();
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var category = GetById(id);
                Context.Remove(category);
                Context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
