using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccessLayer;
using LuongNguyenDuyKhangWPF;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Employee currentLoggedInEmployee;
        public MainWindow(Employee loggedInEmployee)
        {
            InitializeComponent();
            currentLoggedInEmployee = loggedInEmployee;
        }
        private void ManageCustomers_Click(object sender, RoutedEventArgs e)
        {
            var customerWindow = new CustomersWindow();
            customerWindow.ShowDialog();
        }

       private void ManageProducts_Click(object sender, RoutedEventArgs e)
        {
            var productWindow = new ProductsWindow();
            productWindow.ShowDialog();
        }

        private void ManageOrders_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrdersWindow();
            orderWindow.ShowDialog();
        }

        private void ViewReports_Click(object sender, RoutedEventArgs e)
        {
           var reportWindow = new ReportsWindow();
           reportWindow.ShowDialog();
        }
        private void PersonalInformation_Click(object sender, RoutedEventArgs e)
        {
            var personalizationWindow = new PersonalInformationEmployeeWindow(currentLoggedInEmployee);
            personalizationWindow.ShowDialog();
        }
    }
}