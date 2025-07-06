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
    /// Interaction logic for CustomersFormWindow.xaml
    /// </summary>
    public partial class CustomersFormWindow : Window
    {
        ICustomersService customersService = new CustomersService();
        public Customer Customer { get; private set; }
        public CustomersFormWindow()
        {
            InitializeComponent();
            Customer = new Customer();
        }
        public CustomersFormWindow(Customer existingCustomer)
        {
            InitializeComponent();
            Customer = existingCustomer;

            txtCompanyName.Text = Customer.CompanyName;
            txtContactName.Text = Customer.ContactName;
            txtContactTitle.Text = Customer.ContactTitle;
            txtAddress.Text = Customer.Address;
            txtPhone.Text = Customer.Phone;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Customer.CompanyName = txtCompanyName.Text.Trim();
            Customer.ContactName = txtContactName.Text.Trim();
            Customer.ContactTitle = txtContactTitle.Text.Trim();
            Customer.Address = txtAddress.Text.Trim();
            Customer.Phone = txtPhone.Text.Trim();

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
