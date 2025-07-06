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
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        private List<Customer> customers;
        private List<Employee> employees;
        private List<Product> products;
        ICustomersService customersService = new CustomersService();
        IEmployeesService employeesService = new EmployeesService();
        IProductsService productsService = new ProductsService();
        IOrdersService ordersService = new OrdersService();
        IOrderDetailsService orderDetailsService = new OrderDetailsService();

        public OrdersWindow()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = ordersService.GetAllOrders();
            var details = orderDetailsService.GetAllOrderDetails();
            customers = customersService.GetAllCustomers();
            employees = employeesService.GetAllEmployees();
            products = productsService.GetAllProducts();

            var orderDisplayList = (from o in orders
                                    join d in details on o.OrderId equals d.OrderId
                                    join c in customers on o.CustomerId equals c.CustomerId
                                    join e in employees on o.EmployeeId equals e.EmployeeId
                                    join p in products on d.ProductId equals p.ProductId
                                    select new
                                    {
                                        OrderId = o.OrderId,
                                        CustomerID = c.CustomerId,
                                        EmployeeName = e.Name,
                                        OrderDate = o.OrderDate.ToShortDateString(),
                                        ProductName = p.ProductName,
                                        UnitPrice = d.UnitPrice,
                                        Quantity = d.Quantity,
                                        Discount = d.Discount
                                    }).ToList();
            OrdersGrid.ItemsSource = null;
            OrdersGrid.ItemsSource = orderDisplayList;
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            var form = new OrderFormsWindow(customers, employees, products);
            if (form.ShowDialog() == true)
            {
                LoadOrders();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
