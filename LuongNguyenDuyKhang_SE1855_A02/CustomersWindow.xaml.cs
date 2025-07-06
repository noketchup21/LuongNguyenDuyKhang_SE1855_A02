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
    /// Interaction logic for CustomersWindow.xaml
    /// </summary>
    public partial class CustomersWindow : Window
    {
        private readonly ICustomersService customersService = new CustomersService();
        private List<Customer> allCustomers;

        public CustomersWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            allCustomers = customersService.GetAllCustomers();
            dgCustomers.ItemsSource = null;
            dgCustomers.ItemsSource = allCustomers;
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new CustomersFormWindow();
            if (addWindow.ShowDialog() == true)
            {
                var newCustomer = addWindow.Customer;
                customersService.AddCustomer(newCustomer);
                LoadData();
            }
        }

        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selected)
            {
                var editWindow = new CustomersFormWindow(selected);
                if (editWindow.ShowDialog() == true)
                {
                    customersService.UpdateCustomer(editWindow.Customer);
                    LoadData();
                }
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selected)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete customer: {selected.ContactTitle}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        customersService.DeleteCustomer(selected.CustomerId);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        private void SearchCustomer(string keyword)
        {
            var filtered = allCustomers.Where(c =>
                c.CompanyName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                c.ContactName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                c.Phone.Contains(keyword)).ToList();

            dgCustomers.ItemsSource = null;
            dgCustomers.ItemsSource = filtered;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchCustomer(txtSearch.Text.Trim());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
