using HRM.models;
using HRM.Repositories;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HRM.View
{
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
        }


        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Collect data from the form
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string gender = rbMale.IsChecked == true ? "Male" :
                            rbFemale.IsChecked == true ? "Female" : "Other";
            string department = (cbDepartment.SelectedItem as ComboBoxItem)?.Content.ToString();
            string position = (cbPosition.SelectedItem as ComboBoxItem)?.Content.ToString();
            string contactNumber = txtContactNumber.Text;
            string email = txtEmail.Text;
            DateTime? dob = dpDateOfBirth.SelectedDate;
            string password = txtPassword.Password;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(department) || string.IsNullOrWhiteSpace(position) ||
                string.IsNullOrWhiteSpace(contactNumber) || string.IsNullOrWhiteSpace(email) ||
                !dob.HasValue || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create a new Employee object
            Employee newEmployee = new Employee
            {
                id = new EmployRepository().GetNextEmployId(),
                first_name = firstName,
                last_name = lastName,
                pw_hash = password, // Ideally, hash the password before storing
                department = department,
                position = position,
                contact_no = contactNumber,
                email = email,
                dob = dob.Value.ToString("yyyy-MM-dd")
            };

            // Save the employee to the database
            EmployRepository repository = new EmployRepository();
            repository.CreateEmploy(newEmployee);

            MessageBox.Show("Employee registered successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Optionally, clear the form
            ClearForm();
        }

        private void ClearForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            rbMale.IsChecked = false;
            rbFemale.IsChecked = false;
            rbOther.IsChecked = false;
            cbDepartment.SelectedIndex = -1;
            cbPosition.SelectedIndex = -1;
            txtContactNumber.Clear();
            txtEmail.Clear();
            dpDateOfBirth.SelectedDate = null;
            txtPassword.Clear();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Window_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
