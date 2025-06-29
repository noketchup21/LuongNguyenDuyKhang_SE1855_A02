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
    /// Interaction logic for CustomerOrderHistoryWindow.xaml
    /// </summary>
    public partial class CustomerOrderHistoryWindow : Window
    {
        public CustomerOrderHistoryWindow(Customer customer)
        {
            InitializeComponent();
            var orders = OrdersService.Instance.GetAllOrders()
                .Where(o => o.CustomerId == customer.CustomerId)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
            OrdersGrid.ItemsSource = orders;
        }
    }
}
