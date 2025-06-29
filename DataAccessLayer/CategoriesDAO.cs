using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class CategoriesDAO
    {
        private static CategoriesDAO instance;
        public static CategoriesDAO Instance => instance ??= new CategoriesDAO();

        List<Category> categories = new List<Category>();
        public List<Category> GetAllCategories()
        {
            return categories;
        }
        public void AddCategory(Category category)
        {
            if (category != null && !categories.Any(c => c.CategoryId == category.CategoryId))
            {
                categories.Add(category);
            }
        }
        public void UpdateCategory(Category category)
        {
            Category existingCategory = categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
                existingCategory.Description = category.Description;
            }
        }
        public void DeleteCategory(int categoryId)
        {
            Category existingCategory = categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (existingCategory != null)
            {
                categories.Remove(existingCategory);
            }
        }
    }
}
