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
using HRM.Repositories;

namespace HRM.View
{
    /// <summary>
    /// Interaction logic for resetView.xaml
    /// </summary>
    public partial class ResetView : Window
    {
        public ResetView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            // Add logic for resetting the password here  

            string employId = txtEmployeeID.Text;
            string employeepassword = txtNewPass.Password;
            string employeepassword2 = txtVerifyNewPass.Password;

            if (employId == "")
            {
                MessageBox.Show("Please enter Employee ID");
            }
            else if (employeepassword == "")
            {
                MessageBox.Show("Please enter new password");
            }
            else if (employeepassword2 == "")
            {
                MessageBox.Show("Please verify new password");
            }
            else if (employeepassword != employeepassword2)
            {
                MessageBox.Show("Password does not match");
            }
            else
            {
                var repo = new EmployRepository();
                repo.ResetPassword(employId, employeepassword);
                // Logic to reset the password
                MessageBox.Show("Password reset successfully");
                
                this.Close();
                LoginView loginView = new LoginView();
                loginView.Show();
            }

        }
    }
}