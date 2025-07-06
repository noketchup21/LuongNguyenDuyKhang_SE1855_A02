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
    /// Interaction logic for EditCustomerProfileWindow.xaml
    /// </summary>
    public partial class EditCustomerProfileWindow : Window
    {
        ICustomersService customerService = new CustomersService();
        private Customer customer;

        public EditCustomerProfileWindow(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            txtName.Text = customer.ContactName;
            txtPhone.Text = customer.Phone;
            txtAddress.Text = customer.Address;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            customer.ContactName = txtName.Text.Trim();
            customer.Phone = txtPhone.Text.Trim();
            customer.Address = txtAddress.Text.Trim();
            customerService.UpdateCustomer(customer);
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
