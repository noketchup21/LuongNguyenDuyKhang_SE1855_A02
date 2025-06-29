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


namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CustomersMainWindow.xaml
    /// </summary>
    public partial class CustomersMainWindow : Window
    {
        private Customer loggedInCustomer;

        public CustomersMainWindow(Customer customer)
        {
            InitializeComponent();
            loggedInCustomer = customer;
        }

        private void btnViewOrders_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = new CustomerOrderHistoryWindow(loggedInCustomer);
            orderWindow.ShowDialog();
        }

        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {
/*            var profileWindow = new EditCustomerProfileWindow(loggedInCustomer);
            if (profileWindow.ShowDialog() == true)
            {
                MessageBox.Show("Profile updated successfully.");
            }*/
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
    }
}
