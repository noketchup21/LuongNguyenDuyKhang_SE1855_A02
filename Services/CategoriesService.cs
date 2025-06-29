using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Services;

namespace Repositories
{
    public class CategoriesService : ICategoriesRepository
    {
        private static CategoriesService instance;
        public static CategoriesService Instance => instance ??= new CategoriesService();

        private CategoriesRepository _categoriesRepository = CategoriesRepository.Instance;
        public void AddCategory(Category category)
        {
            _categoriesRepository.AddCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoriesRepository.DeleteCategory(categoryId);
        }

        public List<Category> GetAllCategories()
        {
            return _categoriesRepository.GetAllCategories();
        }

        public void UpdateCategory(Category category)
        {
            _categoriesRepository.UpdateCategory(category);
        }
    }
}
