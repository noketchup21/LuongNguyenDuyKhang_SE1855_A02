using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private static ProductsRepository instance;
        public static ProductsRepository Instance => instance ??= new ProductsRepository();

        private ProductsDAO productsDAO = ProductsDAO.Instance;
        public void AddProduct(Product product)
        {
            productsDAO.AddProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            productsDAO.DeleteProduct(productId);
        }


        public List<Product> GetAllProducts()
        {
            return productsDAO.GetAllProducts();
        }

        public string SearchProductByName(string name)
        {
            return productsDAO.SearchProductByName(name);
        }

        public void UpdateProduct(Product product)
        {
            productsDAO.UpdateProduct(product);
        }
    }
}
