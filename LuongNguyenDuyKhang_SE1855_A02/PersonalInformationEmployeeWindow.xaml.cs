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

namespace LuongNguyenDuyKhangWPF
{
    /// <summary>
    /// Interaction logic for PersonalInformationEmployeeWindow.xaml
    /// </summary>
    public partial class PersonalInformationEmployeeWindow : Window
    {
        private Employee currentEmployee;
        private readonly IEmployeesService employeesService = new EmployeesService();
        public PersonalInformationEmployeeWindow(Employee loggedInEmployee)
        {
            InitializeComponent();
            currentEmployee = loggedInEmployee;
            LoadEmployeeData();
        }
        private void LoadEmployeeData()
        {
            txtName.Text = currentEmployee.Name;
            txtUserName.Text = currentEmployee.UserName;
            txtPassword.Password = currentEmployee.Password ?? "";
            txtJobTitle.Text = currentEmployee.JobTitle ?? "";
            dpBirthDate.SelectedDate = currentEmployee.BirthDate;
            dpHireDate.SelectedDate = currentEmployee.HireDate;
            txtAddress.Text = currentEmployee.Address ?? "";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            currentEmployee.Name = txtName.Text.Trim();
            currentEmployee.Password = txtPassword.Password;
            currentEmployee.JobTitle = txtJobTitle.Text.Trim();
            currentEmployee.BirthDate = dpBirthDate.SelectedDate;
            currentEmployee.HireDate = dpHireDate.SelectedDate;
            currentEmployee.Address = txtAddress.Text.Trim();

            employeesService.UpdateEmployee(currentEmployee);
            MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
