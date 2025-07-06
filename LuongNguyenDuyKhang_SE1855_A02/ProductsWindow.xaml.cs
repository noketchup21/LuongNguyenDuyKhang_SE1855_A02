using System;
using System.Collections.Generic;
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
    /// Interaction logic for ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        IProductsService productsService = new ProductsService();

        public ProductsWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgProducts.ItemsSource = null;
            dgProducts.ItemsSource = productsService.GetAllProducts();
        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new ProductsFormWindow();
            if (addWindow.ShowDialog() == true)
            {
                var newProduct = addWindow.Product;
                productsService.AddProduct(newProduct);
                LoadData();
            }
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selected)
            {
                var editWindow = new ProductsFormWindow(selected);
                if (editWindow.ShowDialog() == true)
                {
                    productsService.UpdateProduct(editWindow.Product);
                    LoadData();
                }
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selected)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete product: {selected.ProductName}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    productsService.DeleteProduct(selected.ProductId);
                    LoadData();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchProduct(txtSearch.Text.Trim());
        }

        private void SearchProduct(string keyword)
        {
            var filtered = productsService.GetAllProducts()
                .Where(p => p.ProductName.Contains(keyword, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            dgProducts.ItemsSource = null;
            dgProducts.ItemsSource = filtered;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
