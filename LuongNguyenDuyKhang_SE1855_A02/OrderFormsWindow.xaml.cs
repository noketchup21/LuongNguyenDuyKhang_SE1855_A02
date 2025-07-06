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
    /// Interaction logic for OrderFormsWindow.xaml
    /// </summary>
    public partial class OrderFormsWindow : Window
    {
        public Order Order { get; set; } = new Order();

        ICustomersService customersService = new CustomersService();
        IEmployeesService employeesService = new EmployeesService();
        IProductsService productsService = new ProductsService();
        IOrdersService ordersService = new OrdersService();
        IOrderDetailsService orderDetailsService = new OrderDetailsService();

        private List<Customer> customers;
        private List<Employee> employees;
        private List<Product> products;

        public OrderFormsWindow(List<Customer> customers, List<Employee> employees, List<Product> products)
        {
            InitializeComponent();
            this.customers = customers;
            this.employees = employees;
            this.products = products;

            CustomerComboBox.ItemsSource = customers;
            CustomerComboBox.DisplayMemberPath = "ContactName";
            EmployeeComboBox.ItemsSource = employees;
            EmployeeComboBox.DisplayMemberPath = "Name";
            ProductComboBox.ItemsSource = products;
            ProductComboBox.DisplayMemberPath = "ProductName";
        }

        private void ProductComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ProductComboBox.SelectedItem is Product selectedProduct)
            {
                UnitPriceTextBox.Text = (selectedProduct.UnitPrice ?? 0).ToString("F2");
            }
        }

        private void SaveOrder_Click(object sender, RoutedEventArgs e)
        {
            SaveOrderButton.IsEnabled = false;
            if (CustomerComboBox.SelectedItem is Customer customer &&
                EmployeeComboBox.SelectedItem is Employee employee &&
                ProductComboBox.SelectedItem is Product product &&
                int.TryParse(QuantityTextBox.Text, out int quantity) &&
                decimal.TryParse(UnitPriceTextBox.Text, out decimal unitPrice) &&
                decimal.TryParse(DiscountTextBox.Text, out decimal discount))
            {
                // Create the new order
                int newOrderId = ordersService.GetAllOrders().Max(o => o.OrderId) + 1;
                var newOrder = new Order
                {
                    OrderId = newOrderId,
                    CustomerId = customer.CustomerId,
                    EmployeeId = employee.EmployeeId,
                    OrderDate = DateTime.Now
                };

                ordersService.AddOrder(newOrder);

                var newDetail = new OrderDetail
                {
                    OrderId = newOrder.OrderId,
                    ProductId = product.ProductId,
                    Quantity = (short)quantity,
                    UnitPrice = unitPrice,
                    Discount = (float)discount / 100
                };

                orderDetailsService.AddOrderDetails(newDetail);

                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please fill all fields correctly.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
