using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Services;

namespace Repositories
{
    public class CategoriesService : ICategoriesService
    {
        ICategoriesRepository _categoriesRepository;
        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
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
