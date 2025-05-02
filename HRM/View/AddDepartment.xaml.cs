using HRM.Model;
using HRM.Repositories;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRM.View
{
    /// <summary>
    /// Interaction logic for AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Window
    {
        public AddDepartment()
        {
            InitializeComponent();
        }


        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }

        //validate email
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Use System.Net.Mail to validate email format
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void addDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            string name = departmentName.Text;
            string email = departmentEmail.Text;
            string contact = departmentNumber.Text;
            int employeeCount = int.Parse(departmentCount.Text);

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(contact))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Validate email
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            AttendancePayrollRepository attendancePayrollRepository = new AttendancePayrollRepository();
            DepartmentRepository departmentRepository = new DepartmentRepository();
            Department newDepartment = new Department
            {
                DepartmentId = departmentRepository.GetNextEmployId(),
                Name = name,
                Email = email,
                EmployeeCount = employeeCount,
                Contact = contact
            };
            DepartmentRepository repoi = new DepartmentRepository();
            repoi.CreateDepartment(newDepartment);

            MessageBox.Show("Department created successfully!");
            MessageBox.Show(attendancePayrollRepository.GetNextRowId("Department").ToString());

            this.Close();
        }
    }
}