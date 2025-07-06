using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class CategoriesDAO
    {
        LucySalesDataContext context = new LucySalesDataContext();

        List<Category> categories = new List<Category>();
        public List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }
        public void AddCategory(Category category)
        {
            if (category != null && !categories.Any(c => c.CategoryId == category.CategoryId))
            {
                context.Add(category);
                context.SaveChanges();
            }
        }
        public void UpdateCategory(Category category)
        {
            Category existingCategory = categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
                existingCategory.Description = category.Description;
                context.SaveChanges();
            }
        }
        public void DeleteCategory(int categoryId)
        {
            Category existingCategory = categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (existingCategory != null)
            {
                context.Remove(existingCategory);
                context.SaveChanges();
            }
        }
    }
}
