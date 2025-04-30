using HRM.models;
using HRM.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace HRM.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            //ReadEmploy();
        }
        //drag the window anywhere

        //private void ReadEmploy()
        //{
        //    DataTable dataTable = new DataTable();

        //    dataTable.Columns.Add("ID");
        //    dataTable.Columns.Add("Name");
        //    dataTable.Columns.Add("Department");
        //    dataTable.Columns.Add("Position");
        //    dataTable.Columns.Add("Contact_No");
        //    dataTable.Columns.Add("Email");

        //    var repo = new EmployRepository();
        //    var emplyees = repo.GetEmployees();

        //    foreach (var employ in emplyees)
        //    {
        //        var row = dataTable.NewRow();

        //        row["ID"] = employ.id;
        //        row["Name"] = employ.first_name + " " + employ.last_name;
        //        row["Department"] = employ.department;
        //        row["Position"] = employ.position;
        //        row["Contact_No"] = employ.contact_no;
        //        row["Email"] = employ.email;

        //        dataTable.Rows.Add(row);

        //    }

           

        //}

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string employeeName = txtUser.Text;
            string employeePw = txtPass.Password;
            var repo = new EmployRepository();
            bool result = repo.SignInEmplyee(employeeName, employeePw);
            Employee logedemployee = repo.GetEmployeeByName(employeeName, employeePw);

            if (employeePw == "")
            {
                MessageBox.Show("Please enter password");

            }
            else if (result)
            {
                //MainView mainWindow = new MainView();
                //mainWindow.Show();

                table mainWindow = new table(logedemployee);
                mainWindow.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

 
        //private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}

        //reset 

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResetView resetWindow = new ResetView();
            resetWindow.Show();
            this.Hide();

        }

        
        //register
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RegisterView registerView = new RegisterView();
            registerView.Show();
            this.Hide();
        }


    }
}
