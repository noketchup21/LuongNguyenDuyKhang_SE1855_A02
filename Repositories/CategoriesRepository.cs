using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private static CategoriesRepository instance;
        public static CategoriesRepository Instance => instance ??= new CategoriesRepository();

        private CategoriesDAO categoriesDAO = CategoriesDAO.Instance;
        public void AddCategory(Category category)
        {
            categoriesDAO.AddCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            categoriesDAO.DeleteCategory(categoryId);
        }


        public List<Category> GetAllCategories()
        {
            return categoriesDAO.GetAllCategories();
        }

        public void UpdateCategory(Category category)
        {
            categoriesDAO.UpdateCategory(category);
        }
    }
}
