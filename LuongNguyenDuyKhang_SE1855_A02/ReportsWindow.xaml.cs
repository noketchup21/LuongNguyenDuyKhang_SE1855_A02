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
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ReportsWindow.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {
        IOrdersService ordersService = new OrdersService();
        IOrderDetailsService orderDetailsService = new OrderDetailsService();
        ICustomersService customersService = new CustomersService();
        IEmployeesService employeesService = new EmployeesService();
        IProductsService productsService = new ProductsService();

        public ReportsWindow()
        {
            InitializeComponent();
            dpStartDate.SelectedDate = DateTime.Now.AddDays(-30);
            dpEndDate.SelectedDate = DateTime.Now;

            LoadOrders(dpStartDate.SelectedDate, dpEndDate.SelectedDate);
        }

        private void LoadOrders(DateTime? startDate = null, DateTime? endDate = null)
        {
            var orders = ordersService.GetAllOrders();
            var details = orderDetailsService.GetAllOrderDetails();
            var customers = customersService.GetAllCustomers();
            var employees = employeesService.GetAllEmployees();
            var products = productsService.GetAllProducts();

            // Filter by date range
            if (startDate.HasValue && endDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToList();
            }

            var orderReport = (from o in orders
                               join d in details on o.OrderId equals d.OrderId
                               join c in customers on o.CustomerId equals c.CustomerId
                               join e in employees on o.EmployeeId equals e.EmployeeId
                               join p in products on d.ProductId equals p.ProductId
                               select new
                               {
                                   o.OrderId,
                                   CustomerName = c.ContactName,
                                   EmployeeName = e.Name,
                                   o.OrderDate,
                                   ProductName = p.ProductName,
                                   d.UnitPrice,
                                   d.Quantity,
                                   d.Discount,
                                   Total = d.UnitPrice * d.Quantity * (1 - (decimal)d.Discount)
                               })
                               .OrderByDescending(r => r.OrderDate)
                               .ToList();

            dgOrders.ItemsSource = orderReport;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var start = dpStartDate.SelectedDate;
            var end = dpEndDate.SelectedDate;
            LoadOrders(start, end);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
