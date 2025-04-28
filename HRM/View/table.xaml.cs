using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        public table()
        {
            InitializeComponent();


            var converter = new BrushConverter();
            ObservableCollection<Member> members = new ObservableCollection<Member>();

            // creaate DataGrid Item Info

            members.Add(new Member { Number = "1", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "James Smith", Position = "Manager", Email = "JamesSmith@gmail.com", Phone = "123-456-789" });
            members.Add(new Member { Number = "2", Character = "R", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Christopher Anderson", Position = "Team Lead",Email = "ChristopherAnderson@gmail.com", Phone = "115-484-487" });
            members.Add(new Member { Number = "3", Character = "D", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Ronald Clark", Position = "Team Lead", Email = "RonaldClark@gmail.com", Phone = "985-784-485" });
            members.Add(new Member { Number = "4", Character = "G", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Mary Wright", Position = "Developer", Email = "MaryWright@gmail.com", Phone = "151-658-898" });
            members.Add(new Member { Number = "5", Character = "L", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Lisa Mitchell", Position = "Manager", Email = "LisaMitchell@gmail.com", Phone = "326-598-154" });
            members.Add(new Member { Number = "6", Character = "B", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Michelle Johnson", Position = "Developer", Email = "MichelleJohnson@gmail.com", Phone = "963-214-145" });
            members.Add(new Member { Number = "7", Character = "S", BgColor = (Brush)converter.ConvertFromString("#ff6f00"), Name = "John Thomas", Position = "Intern", Email = "JohnThomas@gmail.com", Phone = "454-454-154" });
            members.Add(new Member { Number = "8", Character = "A", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Daniel Rodriguez", Position = "Intern", Email = "DanielRodriguez@gmail.com", Phone = "021-154-036" });
            members.Add(new Member { Number = "9", Character = "f", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Anthony Lopez", Position = "Developer", Email = "AnthonyLopez@gmail.com", Phone = "746-412-124" });
            members.Add(new Member { Number = "10", Character = "S", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Patricia Perez", Position = "Developer", Email = "PatriciaPerez@gmail.com", Phone = "987-451-326" });


            members.Add(new Member { Number = "1", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "James Smith", Position = "Manager", Email = "JamesSmith@gmail.com", Phone = "123-456-789" });
            members.Add(new Member { Number = "2", Character = "R", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Christopher Anderson", Position = "Team Lead", Email = "ChristopherAnderson@gmail.com", Phone = "115-484-487" });
            members.Add(new Member { Number = "3", Character = "D", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Ronald Clark", Position = "Team Lead", Email = "RonaldClark@gmail.com", Phone = "985-784-485" });
            members.Add(new Member { Number = "4", Character = "G", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Mary Wright", Position = "Developer", Email = "MaryWright@gmail.com", Phone = "151-658-898" });
            members.Add(new Member { Number = "5", Character = "L", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Lisa Mitchell", Position = "Manager", Email = "LisaMitchell@gmail.com", Phone = "326-598-154" });
            members.Add(new Member { Number = "6", Character = "B", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Michelle Johnson", Position = "Developer", Email = "MichelleJohnson@gmail.com", Phone = "963-214-145" });
            members.Add(new Member { Number = "7", Character = "S", BgColor = (Brush)converter.ConvertFromString("#ff6f00"), Name = "John Thomas", Position = "Intern", Email = "JohnThomas@gmail.com", Phone = "454-454-154" });
            members.Add(new Member { Number = "8", Character = "A", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Daniel Rodriguez", Position = "Intern", Email = "DanielRodriguez@gmail.com", Phone = "021-154-036" });
            members.Add(new Member { Number = "9", Character = "f", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Anthony Lopez", Position = "Developer", Email = "AnthonyLopez@gmail.com", Phone = "746-412-124" });
            members.Add(new Member { Number = "10", Character = "S", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Patricia Perez", Position = "Developer", Email = "PatriciaPerez@gmail.com", Phone = "987-451-326" });

            members.Add(new Member { Number = "1", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "James Smith", Position = "Manager", Email = "JamesSmith@gmail.com", Phone = "123-456-789" });
            members.Add(new Member { Number = "2", Character = "R", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Christopher Anderson", Position = "Team Lead", Email = "ChristopherAnderson@gmail.com", Phone = "115-484-487" });
            members.Add(new Member { Number = "3", Character = "D", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Ronald Clark", Position = "Team Lead", Email = "RonaldClark@gmail.com", Phone = "985-784-485" });
            members.Add(new Member { Number = "4", Character = "G", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Mary Wright", Position = "Developer", Email = "MaryWright@gmail.com", Phone = "151-658-898" });
            members.Add(new Member { Number = "5", Character = "L", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Lisa Mitchell", Position = "Manager", Email = "LisaMitchell@gmail.com", Phone = "326-598-154" });
            members.Add(new Member { Number = "6", Character = "B", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Michelle Johnson", Position = "Developer", Email = "MichelleJohnson@gmail.com", Phone = "963-214-145" });
            members.Add(new Member { Number = "7", Character = "S", BgColor = (Brush)converter.ConvertFromString("#ff6f00"), Name = "John Thomas", Position = "Intern", Email = "JohnThomas@gmail.com", Phone = "454-454-154" });
            members.Add(new Member { Number = "8", Character = "A", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Daniel Rodriguez", Position = "Intern", Email = "DanielRodriguez@gmail.com", Phone = "021-154-036" });
            members.Add(new Member { Number = "9", Character = "f", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Anthony Lopez", Position = "Developer", Email = "AnthonyLopez@gmail.com", Phone = "746-412-124" });
            members.Add(new Member { Number = "10", Character = "S", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Patricia Perez", Position = "Developer", Email = "PatriciaPerez@gmail.com", Phone = "987-451-326" });

            members.Add(new Member { Number = "1", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "James Smith", Position = "Manager", Email = "JamesSmith@gmail.com", Phone = "123-456-789" });
            members.Add(new Member { Number = "2", Character = "R", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Christopher Anderson", Position = "Team Lead", Email = "ChristopherAnderson@gmail.com", Phone = "115-484-487" });
            members.Add(new Member { Number = "3", Character = "D", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Ronald Clark", Position = "Team Lead", Email = "RonaldClark@gmail.com", Phone = "985-784-485" });
            members.Add(new Member { Number = "4", Character = "G", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Mary Wright", Position = "Developer", Email = "MaryWright@gmail.com", Phone = "151-658-898" });
            members.Add(new Member { Number = "5", Character = "L", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Lisa Mitchell", Position = "Manager", Email = "LisaMitchell@gmail.com", Phone = "326-598-154" });
            members.Add(new Member { Number = "6", Character = "B", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Michelle Johnson", Position = "Developer", Email = "MichelleJohnson@gmail.com", Phone = "963-214-145" });
            members.Add(new Member { Number = "7", Character = "S", BgColor = (Brush)converter.ConvertFromString("#ff6f00"), Name = "John Thomas", Position = "Intern", Email = "JohnThomas@gmail.com", Phone = "454-454-154" });
            members.Add(new Member { Number = "8", Character = "A", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Daniel Rodriguez", Position = "Intern", Email = "DanielRodriguez@gmail.com", Phone = "021-154-036" });
            members.Add(new Member { Number = "9", Character = "f", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Anthony Lopez", Position = "Developer", Email = "AnthonyLopez@gmail.com", Phone = "746-412-124" });
            members.Add(new Member { Number = "10", Character = "S", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Patricia Perez", Position = "Developer", Email = "PatriciaPerez@gmail.com", Phone = "987-451-326" });

            members.Add(new Member { Number = "1", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "James Smith", Position = "Manager", Email = "JamesSmith@gmail.com", Phone = "123-456-789" });
            members.Add(new Member { Number = "2", Character = "R", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Christopher Anderson", Position = "Team Lead", Email = "ChristopherAnderson@gmail.com", Phone = "115-484-487" });
            members.Add(new Member { Number = "3", Character = "D", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Ronald Clark", Position = "Team Lead", Email = "RonaldClark@gmail.com", Phone = "985-784-485" });
            members.Add(new Member { Number = "4", Character = "G", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Mary Wright", Position = "Developer", Email = "MaryWright@gmail.com", Phone = "151-658-898" });
            members.Add(new Member { Number = "5", Character = "L", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Lisa Mitchell", Position = "Manager", Email = "LisaMitchell@gmail.com", Phone = "326-598-154" });
            members.Add(new Member { Number = "6", Character = "B", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Michelle Johnson", Position = "Developer", Email = "MichelleJohnson@gmail.com", Phone = "963-214-145" });
            members.Add(new Member { Number = "7", Character = "S", BgColor = (Brush)converter.ConvertFromString("#ff6f00"), Name = "John Thomas", Position = "Intern", Email = "JohnThomas@gmail.com", Phone = "454-454-154" });
            members.Add(new Member { Number = "8", Character = "A", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Daniel Rodriguez", Position = "Intern", Email = "DanielRodriguez@gmail.com", Phone = "021-154-036" });
            members.Add(new Member { Number = "9", Character = "f", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Anthony Lopez", Position = "Developer", Email = "AnthonyLopez@gmail.com", Phone = "746-412-124" });
            members.Add(new Member { Number = "10", Character = "S", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Patricia Perez", Position = "Developer", Email = "PatriciaPerez@gmail.com", Phone = "987-451-326" });

            members.Add(new Member { Number = "1", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "James Smith", Position = "Manager", Email = "JamesSmith@gmail.com", Phone = "123-456-789" });
            members.Add(new Member { Number = "2", Character = "R", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Christopher Anderson", Position = "Team Lead", Email = "ChristopherAnderson@gmail.com", Phone = "115-484-487" });
            members.Add(new Member { Number = "3", Character = "D", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Ronald Clark", Position = "Team Lead", Email = "RonaldClark@gmail.com", Phone = "985-784-485" });
            members.Add(new Member { Number = "4", Character = "G", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Mary Wright", Position = "Developer", Email = "MaryWright@gmail.com", Phone = "151-658-898" });
            members.Add(new Member { Number = "5", Character = "L", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Lisa Mitchell", Position = "Manager", Email = "LisaMitchell@gmail.com", Phone = "326-598-154" });
            members.Add(new Member { Number = "6", Character = "B", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Michelle Johnson", Position = "Developer", Email = "MichelleJohnson@gmail.com", Phone = "963-214-145" });
            members.Add(new Member { Number = "7", Character = "S", BgColor = (Brush)converter.ConvertFromString("#ff6f00"), Name = "John Thomas", Position = "Intern", Email = "JohnThomas@gmail.com", Phone = "454-454-154" });
            members.Add(new Member { Number = "8", Character = "A", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Daniel Rodriguez", Position = "Intern", Email = "DanielRodriguez@gmail.com", Phone = "021-154-036" });
            members.Add(new Member { Number = "9", Character = "f", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Anthony Lopez", Position = "Developer", Email = "AnthonyLopez@gmail.com", Phone = "746-412-124" });
            members.Add(new Member { Number = "10", Character = "S", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Patricia Perez", Position = "Developer", Email = "PatriciaPerez@gmail.com", Phone = "987-451-326" });

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
