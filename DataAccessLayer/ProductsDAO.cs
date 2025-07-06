using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class ProductsDAO
    {
        LucySalesDataContext context = new LucySalesDataContext();

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }
        public void AddProduct(Product product)
        {
            if (product != null && !GetAllProducts().Any(p => p.ProductId == product.ProductId))
            {
                context.Add(product);
                context.SaveChanges();
            }
        }
        public void UpdateProduct(Product product)
        {
            Product existingProduct = GetAllProducts().FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.UnitsInStock = product.UnitsInStock;
                existingProduct.Discontinued = product.Discontinued;
                context.SaveChanges();
            }
        }
        public void DeleteProduct(int productId)
        {
            Product existingProduct = GetAllProducts().FirstOrDefault(p => p.ProductId == productId);
            if (existingProduct != null)
            {
                context.Remove(existingProduct);
                context.SaveChanges();
            }
        }
        public string SearchProductByName(string name)
        {
            var product = GetAllProducts().FirstOrDefault(p => p.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
            return product != null ? $"Found: {product.ProductName}, Price: {product.UnitPrice}" : "Product not found";
        }
    }
}
