using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class ProductsDAO
    {
        private static ProductsDAO instance;
        public static ProductsDAO Instance => instance ??= new ProductsDAO();

        List<Product> products = new List<Product>();
        public List<Product> GetAllProducts()
        {
            return products;
        }
        public void AddProduct(Product product)
        {
            if (product != null && !products.Any(p => p.ProductId == product.ProductId))
            {
                products.Add(product);
            }
        }
        public void UpdateProduct(Product product)
        {
            Product existingProduct = products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.UnitsInStock = product.UnitsInStock;
                existingProduct.Discontinued = product.Discontinued;
            }
        }
        public void DeleteProduct(int productId)
        {
            Product existingProduct = products.FirstOrDefault(p => p.ProductId == productId);
            if (existingProduct != null)
            {
                products.Remove(existingProduct);
            }
        }
        public string SearchProductByName(string name)
        {
            var product = products.FirstOrDefault(p => p.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
            return product != null ? $"Found: {product.ProductName}, Price: {product.UnitPrice}" : "Product not found";
        }
    }
}
