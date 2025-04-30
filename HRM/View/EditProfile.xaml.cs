using HRM.models;
using HRM.Repositories;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HRM.View
{
    public partial class EditProfile : Window
    {
        private Employee selectedEmployee; // Declare selectedEmployee as a class-level field

        public EditProfile(Employee selectedEmployee)
        {
            InitializeComponent();

            this.selectedEmployee = selectedEmployee; // Assign the parameter to the class-level field

            // Assign gender radio button based on the selectedEmployee's gender
            if (selectedEmployee.gender == "Male")
            {
                rbMale.IsChecked = true;
            }
            else if (selectedEmployee.gender == "Female")
            {
                rbFemale.IsChecked = true;
            }
            else
            {
                rbOther.IsChecked = true;
            }

            txtFirstName.Text = selectedEmployee.first_name;
            txtLastName.Text = selectedEmployee.last_name;
            txtEmail.Text = selectedEmployee.email;
            txtContactNumber.Text = selectedEmployee.contact_no;

            // Fix for the errors
            dpDateOfBirth.SelectedDate = selectedEmployee.dob != null
                ? DateTime.Parse(selectedEmployee.dob)
                : (DateTime?)null;

            // Set the selected item in the ComboBox based on the selectedEmployee's department and position
            cbDepartment.SelectedItem = cbDepartment.Items
                .Cast<ComboBoxItem>()
                .FirstOrDefault(item => (item.Content as string) == selectedEmployee.department);

            cbPosition.SelectedItem = cbPosition.Items
                .Cast<ComboBoxItem>()
                .FirstOrDefault(item => (item.Content as string) == selectedEmployee.position);
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

            // Validate inputs
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(department) || string.IsNullOrWhiteSpace(position) ||
                string.IsNullOrWhiteSpace(contactNumber) || string.IsNullOrWhiteSpace(email) ||
                !dob.HasValue)
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create a new Employee object
            Employee editEmployee = new Employee
            {
                id = selectedEmployee.id, // Use the class-level field
                first_name = firstName,
                last_name = lastName,
                department = department,
                position = position,
                contact_no = contactNumber,
                email = email,
                dob = dob.Value.ToString("yyyy-MM-dd"),
                gender = gender,
                pw_hash = selectedEmployee.pw_hash // Keep the original password hash
            };

            // Save the employee to the database
            EmployRepository repository = new EmployRepository();
            repository.UpdateEmploy(editEmployee);

            table table = new table(selectedEmployee);
            table.Show();

            this.Close();

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
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }

        private void Window_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }
    }
}
