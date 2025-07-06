using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using Repositories;

namespace Services
{
    public class ProductsService : IProductsService
    {
        IProductsRepository _productsRepository;
        public ProductsService()
        {
            _productsRepository = new ProductsRepository();
        }

        public void AddProduct(Product product)
        {
            _productsRepository.AddProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            _productsRepository.DeleteProduct(productId);
        }


        public List<Product> GetAllProducts()
        {
            return _productsRepository.GetAllProducts();
        }

        public string SearchProductByName(string name)
        {
            return _productsRepository.SearchProductByName(name);
        }

        public void UpdateProduct(Product product)
        {
            _productsRepository.UpdateProduct(product);
        }
    }
}
