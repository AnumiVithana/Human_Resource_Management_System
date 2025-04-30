using HRM.models;
using HRM.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace HRM.View
{
    /// <summary>
    /// Interaction logic for table.xaml
    /// </summary>
    public partial class table : Window
    {

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            LoginView firstWindow = new LoginView();
            firstWindow.Show();
            this.Hide();
        }

        


        public table()
        {
            InitializeComponent();


            var converter = new BrushConverter();
            ObservableCollection<Member> members = new ObservableCollection<Member>();
            var repo = new EmployRepository();
            var emplyees = repo.GetEmployees();
            

            foreach (var employ in emplyees)
            {
                members.Add(new Member
                {
                    Number = employ.id.ToString(), // Convert int to string
                    Character = employ.first_name[0].ToString(),
                    BgColor = (Brush)converter.ConvertFromString("#1098ad"),
                    Name = employ.first_name + " " + employ.last_name, // Use employee's actual name
                    Position = employ.position,
                    Email = employ.email,
                    Phone = employ.contact_no
                });
            }
            memberDataGrid.ItemsSource = members;
            
        }




        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { 
                this.DragMove();
            }
        }

        private bool IsMaximized = false;
        private object someGrid;

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else { 
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dashBoardGrid.Visibility = Visibility.Visible;
            eventGrid.Visibility = Visibility.Hidden;
            departmentGrid.Visibility = Visibility.Hidden;
            membersGrid.Visibility = Visibility.Hidden;
            performanceGrid.Visibility = Visibility.Hidden;
            salaryGrid.Visibility = Visibility.Hidden;
            requestLeaveGrid.Visibility = Visibility.Hidden;
            MyProfileGrid.Visibility = Visibility.Hidden;

            MyProfileButton.Background = System.Windows.Media.Brushes.Transparent;



            EventButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
            MembersButton.Background = System.Windows.Media.Brushes.Transparent;
            PerformanceButton.Background = System.Windows.Media.Brushes.Transparent;
            SalaryButton.Background = System.Windows.Media.Brushes.Transparent;
            RequestLeaveButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.White;


        }

        private void EventButton_Click(object sender, RoutedEventArgs e)
        {
            dashBoardGrid.Visibility = Visibility.Hidden;
            eventGrid.Visibility = Visibility.Visible;
            departmentGrid.Visibility = Visibility.Hidden;
            membersGrid.Visibility = Visibility.Hidden;
            performanceGrid.Visibility = Visibility.Hidden;
            salaryGrid.Visibility = Visibility.Hidden;
            requestLeaveGrid.Visibility = Visibility.Hidden;
            MyProfileGrid.Visibility = Visibility.Hidden;

            MyProfileButton.Background = System.Windows.Media.Brushes.Transparent;

            EventButton.Background = System.Windows.Media.Brushes.White;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
            MembersButton.Background = System.Windows.Media.Brushes.Transparent;
            PerformanceButton.Background = System.Windows.Media.Brushes.Transparent;
            SalaryButton.Background = System.Windows.Media.Brushes.Transparent;
            RequestLeaveButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
        }

        private void DepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            dashBoardGrid.Visibility = Visibility.Hidden;
            eventGrid.Visibility = Visibility.Hidden;
            departmentGrid.Visibility = Visibility.Visible;
            membersGrid.Visibility = Visibility.Hidden;
            performanceGrid.Visibility = Visibility.Hidden;
            salaryGrid.Visibility = Visibility.Hidden;
            requestLeaveGrid.Visibility = Visibility.Hidden;
            MyProfileGrid.Visibility = Visibility.Hidden;

            MyProfileButton.Background = System.Windows.Media.Brushes.Transparent;

            EventButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.White;
            MembersButton.Background = System.Windows.Media.Brushes.Transparent;
            PerformanceButton.Background = System.Windows.Media.Brushes.Transparent;
            SalaryButton.Background = System.Windows.Media.Brushes.Transparent;
            RequestLeaveButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
        }

        private void MembersButton_Click(object sender, RoutedEventArgs e)
        {
            dashBoardGrid.Visibility = Visibility.Hidden;
            eventGrid.Visibility = Visibility.Hidden;
            departmentGrid.Visibility = Visibility.Hidden;
            membersGrid.Visibility = Visibility.Visible;
            performanceGrid.Visibility = Visibility.Hidden;
            salaryGrid.Visibility = Visibility.Hidden;
            requestLeaveGrid.Visibility = Visibility.Hidden;
            MyProfileGrid.Visibility = Visibility.Hidden;

            MyProfileButton.Background = System.Windows.Media.Brushes.Transparent;

            EventButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
            MembersButton.Background = System.Windows.Media.Brushes.White;
            PerformanceButton.Background = System.Windows.Media.Brushes.Transparent;
            SalaryButton.Background = System.Windows.Media.Brushes.Transparent;
            RequestLeaveButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
        }

        private void PerformanceButton_Click(object sender, RoutedEventArgs e)
        {
            dashBoardGrid.Visibility = Visibility.Hidden;
            eventGrid.Visibility = Visibility.Hidden;
            departmentGrid.Visibility = Visibility.Hidden;
            membersGrid.Visibility = Visibility.Hidden;
            performanceGrid.Visibility = Visibility.Visible;
            salaryGrid.Visibility = Visibility.Hidden;
            requestLeaveGrid.Visibility = Visibility.Hidden;
            MyProfileGrid.Visibility = Visibility.Hidden;

            MyProfileButton.Background = System.Windows.Media.Brushes.Transparent;

            EventButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
            MembersButton.Background = System.Windows.Media.Brushes.Transparent;
            PerformanceButton.Background = System.Windows.Media.Brushes.White;
            SalaryButton.Background = System.Windows.Media.Brushes.Transparent;
            RequestLeaveButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
        }

        private void SalaryButton_Click(object sender, RoutedEventArgs e)
        {
            dashBoardGrid.Visibility = Visibility.Hidden;
            eventGrid.Visibility = Visibility.Hidden;
            departmentGrid.Visibility = Visibility.Hidden;
            membersGrid.Visibility = Visibility.Hidden;
            performanceGrid.Visibility = Visibility.Hidden;
            salaryGrid.Visibility = Visibility.Visible;
            requestLeaveGrid.Visibility = Visibility.Hidden;
            MyProfileGrid.Visibility = Visibility.Hidden;

            MyProfileButton.Background = System.Windows.Media.Brushes.Transparent;

            EventButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
            MembersButton.Background = System.Windows.Media.Brushes.Transparent;
            PerformanceButton.Background = System.Windows.Media.Brushes.Transparent;
            SalaryButton.Background = System.Windows.Media.Brushes.White;
            RequestLeaveButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
        }

        private void RequestLeaveButton_Click(object sender, RoutedEventArgs e)
        {
            dashBoardGrid.Visibility = Visibility.Hidden;
            eventGrid.Visibility = Visibility.Hidden;
            departmentGrid.Visibility = Visibility.Hidden;
            membersGrid.Visibility = Visibility.Hidden;
            performanceGrid.Visibility = Visibility.Hidden;
            salaryGrid.Visibility = Visibility.Hidden;
            requestLeaveGrid.Visibility = Visibility.Visible;
            MyProfileGrid.Visibility = Visibility.Hidden;   

            MyProfileButton.Background = System.Windows.Media.Brushes.Transparent;

            EventButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
            MembersButton.Background = System.Windows.Media.Brushes.Transparent;
            PerformanceButton.Background = System.Windows.Media.Brushes.Transparent;
            SalaryButton.Background = System.Windows.Media.Brushes.Transparent;
            RequestLeaveButton.Background = System.Windows.Media.Brushes.White;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
        }


        //My Profile Button
        private void MyProfileButton_Click(object sender, RoutedEventArgs e)
        {
            dashBoardGrid.Visibility = Visibility.Hidden;
            eventGrid.Visibility = Visibility.Hidden;
            departmentGrid.Visibility = Visibility.Hidden;
            membersGrid.Visibility = Visibility.Hidden;
            performanceGrid.Visibility = Visibility.Hidden;
            salaryGrid.Visibility = Visibility.Hidden;
            requestLeaveGrid.Visibility = Visibility.Hidden;
            MyProfileGrid.Visibility = Visibility.Visible;

            EventButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
            MembersButton.Background = System.Windows.Media.Brushes.Transparent;
            PerformanceButton.Background = System.Windows.Media.Brushes.Transparent;
            SalaryButton.Background = System.Windows.Media.Brushes.Transparent;
            RequestLeaveButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
            MyProfileButton.Background = System.Windows.Media.Brushes.White;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();

        }


        // Fix for CS0103: The name 'ConvertFromString' does not exist in the current context
        // Replace the line causing the error with the correct usage of the BrushConverter.

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtBlockFilter.Text = "";
            var repo = new EmployRepository();
            var emplyees = repo.GetEmployees();

            var converter = new BrushConverter(); // Ensure BrushConverter is instantiated
            ObservableCollection<Member> members = new ObservableCollection<Member>();

            foreach (var employ in emplyees)
            {
                var name = employ.first_name + " " + employ.last_name;
                // Fix for CS1501: Use string.StartsWith instead of invalid index range comparison
                if (name.StartsWith(txtFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                    employ.last_name.Equals(txtFilter.Text, StringComparison.OrdinalIgnoreCase))
                {
                    members.Add(new Member
                    {
                        Number = employ.id.ToString(), // Convert int to string
                        Character = employ.first_name[0].ToString(),
                        BgColor = (Brush)converter.ConvertFromString("#1098ad"), // Correct usage of BrushConverter
                        Name = employ.first_name + " " + employ.last_name, // Use employee's actual name
                        Position = employ.position,
                        Email = employ.email,
                        Phone = employ.contact_no
                    });
                }
            }
            memberDataGrid.ItemsSource = members;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RegisterView registerView = new RegisterView();
            registerView.Show();
            this.Hide();
        }
         //edit profile
        private void EditDetailsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }





            }
            else
            {
                MessageBox.Show("No member is selected.");
            }
        }
    }
    public class Member {
        public String Character { get; set; }
        public String Number { get; set; }
        public String Name { get; set; }
        public String Position { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public Brush BgColor { get; set; }

    }



    
    }
