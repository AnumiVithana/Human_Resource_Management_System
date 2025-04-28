using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace HRM.View
{
    /// <summary>
    /// Interaction logic for table.xaml
    /// </summary>
    public partial class table : Window
    {
        public table()
        {
            InitializeComponent();
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

            EventButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
            MembersButton.Background = System.Windows.Media.Brushes.Transparent;
            PerformanceButton.Background = System.Windows.Media.Brushes.Transparent;
            SalaryButton.Background = System.Windows.Media.Brushes.Transparent;
            RequestLeaveButton.Background = System.Windows.Media.Brushes.White;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();

        }
    }
}
