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
using DataAccessLayer;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IEmployeesService employeeService = new EmployeesService();
        ICustomersService customersService = new CustomersService();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (chkIsCustomer.IsChecked == true)
            {
                string phone = txtPhone.Text.Trim();
                var customer = customersService.GetAllCustomers()
                    .FirstOrDefault(c => c.Phone == phone);

                if (customer != null)
                {
                    MessageBox.Show("Customer login successful!", "Success");
                    new CustomersMainWindow(customer).Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Phone number not found.", "Login Failed");
                }
            }
            else
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Password.Trim();

                var employee = employeeService.GetAllEmployees()
                    .FirstOrDefault(e => e.UserName == username && e.Password == password);

                if (employee != null)
                {
                    MessageBox.Show("Employee login successful!", "Success");
                    new MainWindow().Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed");
                }
            }
        }

        private void chkIsCustomer_Checked(object sender, RoutedEventArgs e)
        {
            stackUsername.Visibility = Visibility.Collapsed;
            stackPassword.Visibility = Visibility.Collapsed;
            stackPhone.Visibility = Visibility.Visible;
        }

        private void chkIsCustomer_Unchecked(object sender, RoutedEventArgs e)
        {
            stackUsername.Visibility = Visibility.Visible;
            stackPassword.Visibility = Visibility.Visible;
            stackPhone.Visibility = Visibility.Collapsed;
        }
    }
}
