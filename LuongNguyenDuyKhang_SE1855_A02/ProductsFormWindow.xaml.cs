using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using DataAccessLayer;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductsFormWindow.xaml
    /// </summary>
    public partial class ProductsFormWindow : Window
    {
        public Product Product { get; set; }
        IProductsService productsService = new ProductsService();
        public ProductsFormWindow()
        {
            InitializeComponent();
            Product = new Product();
        }
        public ProductsFormWindow(Product existingProduct)
        {
            InitializeComponent();
            Product = existingProduct;

            txtProductName.Text = Product.ProductName;
            txtSupplierId.Text = Product.SupplierId?.ToString() ?? "";
            txtCategoryId.Text = Product.CategoryId?.ToString() ?? "";
            txtQuantityPerUnit.Text = Product.QuantityPerUnit;
            txtUnitPrice.Text = Product.UnitPrice?.ToString(CultureInfo.InvariantCulture) ?? "";
            txtUnitsInStock.Text = Product.UnitsInStock.ToString();
            txtUnitsOnOrder.Text = Product.UnitsOnOrder.ToString();
            txtReorderLevel.Text = Product.ReorderLevel.ToString();
            chkDiscontinued.IsChecked = Product.Discontinued;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                !decimal.TryParse(txtUnitPrice.Text, out decimal price) ||
                !int.TryParse(txtUnitsInStock.Text, out int stock) ||
                !int.TryParse(txtUnitsOnOrder.Text, out int onOrder) ||
                !int.TryParse(txtReorderLevel.Text, out int reorderLevel) ||
                !int.TryParse(txtSupplierId.Text, out int supplierId) ||
                !int.TryParse(txtCategoryId.Text, out int categoryId))
            {
                MessageBox.Show("Please enter valid product data.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Product.ProductName = txtProductName.Text.Trim();
            Product.SupplierId = supplierId;
            Product.CategoryId = categoryId;
            Product.QuantityPerUnit = txtQuantityPerUnit.Text.Trim();
            Product.UnitPrice = price;
            Product.UnitsInStock = stock;
            Product.UnitsOnOrder = onOrder;
            Product.ReorderLevel = reorderLevel;
            Product.Discontinued = chkDiscontinued.IsChecked == true;

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
