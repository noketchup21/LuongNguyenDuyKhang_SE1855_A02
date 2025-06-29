using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace Repositories
{
    public interface IProductsRepository
    {

        public List<Product> GetAllProducts();
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int productId);
        public string SearchProductByName(string name);
    }
}
