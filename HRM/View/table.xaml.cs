using HRM.models;
using HRM.Model;
using HRM.Repositories;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;
using System.IO;
using System.Drawing.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf;


namespace HRM.View
{
    //------------------------------------------------------------Main Constructor ------------------------------------------------------------
    public partial class table : Window
    {
        private DateTime? checkInTime = null;
        //private DateTime? checkOutTime = null;
        public EmployeeInfomation EmployeeInfomatic { get; set; }
        private Employee LogedEmployee;

        public table(Employee logedEmployee)
        {


            InitializeComponent();
            LogedEmployee = logedEmployee;
            ShowGreeting(logedEmployee.first_name);
            ShowDate();
            LoadSalaryDetails();
            LoadLeaveDetails();

            if (logedEmployee.position == "Admin")
            {

                editDeleteColoumn.Visibility = Visibility.Visible;
                dashBoardAdminGrid.Visibility = Visibility.Visible;
                dashBoardGrid.Visibility = Visibility.Hidden;
            }

            txtFirstName.Text = logedEmployee.first_name;
            txtLastName.Text = logedEmployee.last_name;
            txtEmail.Text = logedEmployee.email;
            txtContactNumber.Text = logedEmployee.contact_no;
            txtDepartment.Text = logedEmployee.department;
            txtPosition.Text = logedEmployee.position;
            txtDOB.Text = logedEmployee.dob;

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

            ObservableCollection<Request> requests = new ObservableCollection<Request>();
            var Repo = new AttendancePayrollRepository();
            var leaveRequests = Repo.GetLeaves();

            string status = "";

            foreach (var leave in leaveRequests)
            {
                var Employee = repo.GetEmploy(leave.employee_id);
                if(leave.status == "1")
                {
                    status = "Approved";
                }
                else if (leave.status == "0")
                {
                    status = "Declined";
                }
                else if (leave.status == null)
                {
                    status = "Pending";
                }
                else
                {
                    status = "Unknown";
                }

                requests.Add(new Request
                    {
                        No = leave.id,
                        EmployeeName = Employee.first_name + " " + Employee.last_name,
                        EmployeePosition = Employee.position,
                        LeaveDate = leave.dateRequested,
                        Reason = leave.reason,
                        State = status,
                        LeaveType = leave.leave_type



                    });
            }
            RequestDataGrid.ItemsSource = requests;



            // ---------------------employee databace info ------------------------------
            EmployeeInfomatic = new EmployeeInfomation
            {
                CasualLeave = "6",
                SickLeave = "4",
                AnnualLeave = "15",
                PresentDays = "18",
                AbsentDays = "2",
                LateDays = "3",
                LastSalary = "Rs. 120,000",
                SalaryMonth = "March 2023",
                PerformanceScore = "4.3 / 5",
                LastReviewMonth = "January 2023"
            };
            DataContext = EmployeeInfomatic;
        }

        // ---------------------Buttons min and close ------------------------------
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




        // ----------------------------------------------------------------DashBoard Admin and employee----------------------------------------------------------------
        private void ShowGreeting(string name)
        {
            var hour = DateTime.Now.Hour;
            string greeting;

            if (hour < 12)
                greeting = "Good Morning";
            else if (hour < 18)
                greeting = "Good Afternoon";
            else
                greeting = "Good Evening";

            txtGreeting.Text = $"{greeting}, {name}!";
            txtGreeting_employee.Text = $"{greeting}, {name}!";
        }

        private void ShowDate()
        {

            txtDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            txtDate_employee.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
        }




        // ----------------------------------------------------------------DashBoard employee check button----------------------------------------------------------------
        private void btnCheckIn_Click(object sender, RoutedEventArgs e)
        {
            checkInTime = DateTime.Now;
            txtCheckInTime.Text = checkInTime.Value.ToString("hh:mm tt");
            txtStatus.Text = $"Checked in at {txtCheckInTime.Text}";

            btnCheckIn.Visibility = Visibility.Collapsed;
            btnCheckOut.Visibility = Visibility.Visible;
            statusPanel.Visibility = Visibility.Visible;
        }

        // Fix for CS0029: Cannot implicitly convert type 'string' to 'int'
        // Update the 'workedHovers' assignment to parse the string value into an integer.

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            // Validation
            if (chkConfirmWorkday.IsChecked != true)
            {
                MessageBox.Show("Please confirm your workday by checking the box.", "Confirmation Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmployeeNote.Text))
            {
                MessageBox.Show("Please enter your notes before checking out.", "Note Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Check-out logic
            if (checkInTime == null)
            {
                MessageBox.Show("You must check in first!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime checkOutTime = DateTime.Now;
            txtCheckOutTime.Text = checkOutTime.ToString("hh:mm tt");

            // Calculate working hours
            TimeSpan duration = checkOutTime - checkInTime.Value;
            txtWorkingHours.Text = $"{(int)duration.TotalHours}h {duration.Minutes}m";

            txtStatus.Text = "Checked out successfully!";
            btnCheckOut.Visibility = Visibility.Collapsed;





            var repo = new AttendancePayrollRepository();
            Attendance attendance = new Attendance
            {
                id = repo.GetNextRowId("attendance"),
                date = DateTime.Now.ToString("yyyy-MM-dd"),
                employeeId = LogedEmployee.id,
                checkInTime = checkInTime.Value.ToString("hh:mm tt"),
                checkOutTime = checkOutTime.ToString("hh:mm tt"),
                workedHovers = (int)duration.TotalHours, // Convert the total hours to an integer
                description = txtEmployeeNote.Text
            };
            repo.CreateAttendancerow(attendance);
            

        }





        // ---------------------------------------------------------------employee databace info end---------------------------------------------------------------
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximized = false;
        private object someGrid;

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }

            }
        }
        // ------------------------------------------------------------ Left site Button clicks ------------------------------------------------------------
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

            if (LogedEmployee.position == "Admin")
            {
                // Assuming 'editDeleteColoumn' is a UI element like a DataGridColumn
                editDeleteColoumn.Visibility = Visibility.Visible;
                dashBoardAdminGrid.Visibility = Visibility.Visible;
                dashBoardGrid.Visibility = Visibility.Hidden;
            }
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
            dashBoardAdminGrid.Visibility = Visibility.Hidden;


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
            dashBoardAdminGrid.Visibility = Visibility.Hidden;


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
            dashBoardAdminGrid.Visibility = Visibility.Hidden;


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
            dashBoardAdminGrid.Visibility = Visibility.Hidden;


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
            dashBoardAdminGrid.Visibility = Visibility.Hidden;


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
            dashBoardAdminGrid.Visibility = Visibility.Hidden;


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
            dashBoardAdminGrid.Visibility = Visibility.Hidden;


            EventButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
            MembersButton.Background = System.Windows.Media.Brushes.Transparent;
            PerformanceButton.Background = System.Windows.Media.Brushes.Transparent;
            SalaryButton.Background = System.Windows.Media.Brushes.Transparent;
            RequestLeaveButton.Background = System.Windows.Media.Brushes.Transparent;
            DashBoardButton.Background = System.Windows.Media.Brushes.Transparent;
            MyProfileButton.Background = System.Windows.Media.Brushes.White;

            var repo = new EmployRepository();
            LogedEmployee = repo.GetEmploy(LogedEmployee.id);

            txtFirstName.Text = LogedEmployee.first_name;
            txtLastName.Text = LogedEmployee.last_name;
            txtEmail.Text = LogedEmployee.email;
            txtContactNumber.Text = LogedEmployee.contact_no;
            txtDepartment.Text = LogedEmployee.department;
            txtPosition.Text = LogedEmployee.position;
            txtDOB.Text = LogedEmployee.dob;
            EditProfile editProfile = new EditProfile(LogedEmployee);



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();

        }


        //------------------------------------------------------------Member------------------------------------------------------------

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
            EditProfile editProfile = new EditProfile(LogedEmployee);
            editProfile.Show();
            this.Close();

        }

        // ----- employeee edit button --------
        private void employeeEdit(object sender, RoutedEventArgs e)
        {
            if (memberDataGrid.SelectedItem is Member selectedMember)
            {
                int selectedId = int.Parse(selectedMember.Number);



                var repo = new EmployRepository();
                Employee selectedEmployee = repo.GetEmploy(selectedId);

                EditProfile editProfile = new EditProfile(selectedEmployee);
                editProfile.Show();
                this.Close();

                var emplyees = repo.GetEmployees();

                var converter = new BrushConverter();
                ObservableCollection<Member> members = new ObservableCollection<Member>();

                foreach (var employ in emplyees)
                {
                    var name = employ.first_name + " " + employ.last_name;
                    if (name.StartsWith(txtFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                        employ.last_name.Equals(txtFilter.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        members.Add(new Member
                        {
                            Number = employ.id.ToString(),
                            Character = employ.first_name[0].ToString(),
                            BgColor = (Brush)converter.ConvertFromString("#1098ad"),
                            Name = employ.first_name + " " + employ.last_name,
                            Position = employ.position,
                            Email = employ.email,
                            Phone = employ.contact_no
                        });
                    }
                }
                memberDataGrid.ItemsSource = members;





            }
            else
            {
                MessageBox.Show("No member is selected.");
            }
        }


        // ----- employeee delete button --------
        private void employeeDelete(object sender, RoutedEventArgs e)
        {
            if (memberDataGrid.SelectedItem is Member selectedMember)
            {
                int selectedId = int.Parse(selectedMember.Number);

                MessageBoxResult dialogResult = MessageBox.Show(
                    "Are you sure you want to delete this employee?",
                    "Delete Confirmation",
                    MessageBoxButton.YesNo
                );

                if (dialogResult == MessageBoxResult.No)
                {
                    return;
                }

                var repo = new EmployRepository();
                repo.DeleteEmploy(selectedId);

                var emplyees = repo.GetEmployees();

                var converter = new BrushConverter();
                ObservableCollection<Member> members = new ObservableCollection<Member>();

                foreach (var employ in emplyees)
                {
                    var name = employ.first_name + " " + employ.last_name;
                    if (name.StartsWith(txtFilter.Text, StringComparison.OrdinalIgnoreCase) ||
                        employ.last_name.Equals(txtFilter.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        members.Add(new Member
                        {
                            Number = employ.id.ToString(),
                            Character = employ.first_name[0].ToString(),
                            BgColor = (Brush)converter.ConvertFromString("#1098ad"),
                            Name = employ.first_name + " " + employ.last_name,
                            Position = employ.position,
                            Email = employ.email,
                            Phone = employ.contact_no
                        });
                    }
                }
                memberDataGrid.ItemsSource = members;





            }
            else
            {
                MessageBox.Show("No member is selected.");
            }
        }



        //------------------------------------------------------------Salary------------------------------------------------------------
        private void LoadSalaryDetails()
        {
            int hourRate = 150;
            int serviceFee = 200;
            int extraLeaves = 2;
            switch (LogedEmployee.position)
            {
                case "Employee":
                    // Code to execute if variable == value1
                    hourRate = 150;
                    serviceFee = 200;
                    extraLeaves = 2;
                    break;

                case "Department Head":
                    hourRate = 150;
                    serviceFee = 200;
                    extraLeaves = 2;
                    // Code to execute if variable == value2
                    break;

                default:
                    hourRate = 150;
                    serviceFee = 200;
                    extraLeaves = 2;
                    // Code to execute if no case matches
                    break;
            }

            SalaryDetails salary = new SalaryDetails
            {
                Month = "April 2025",
                HourRate = hourRate,
                ServiceFee = serviceFee,
                ExtraLeaves = extraLeaves,
                BasicSalary = 24000,
                OTSalary = 5000,
                LeaveDeduction = 1000,
                TotalSalary = 28000
            };

            salaryGrid.DataContext = salary;
        }

        [Obsolete]
        private void GeneratePDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SalaryDetails salary = salaryGrid.DataContext as SalaryDetails;

                if (salary == null)
                {
                    MessageBox.Show("Salary details not loaded.");
                    return;
                }

                PdfDocument document = new PdfDocument();
                document.Info.Title = "Payroll Report";

                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont titleFont = new XFont("Verdana", 20, XFontStyleEx.Regular);
                XFont labelFont = new XFont("Verdana", 12, XFontStyleEx.Regular);
                XFont boldFont = new XFont("Verdana", 12, XFontStyleEx.Bold);
                int y = 50;

                gfx.DrawString("Payroll Report", titleFont, XBrushes.Black, new XRect(0, y, page.Width, 30), XStringFormats.TopCenter);
                y += 50;

                void DrawRow(string label, string value, bool isBold = false)
                {
                    gfx.DrawString(label, isBold ? boldFont : labelFont, XBrushes.Black, new XPoint(50, y));
                    gfx.DrawString(value, isBold ? boldFont : labelFont, XBrushes.Black, new XPoint(300, y));
                    y += 25;
                }

                // Add Salary Details to the PDF
                DrawRow("Month:", salary.Month);
                DrawRow("Basic Hour Rate:", salary.HourRate.ToString("C"));
                DrawRow("Service Fee:", salary.ServiceFee.ToString("C"));
                DrawRow("No. of Extra Leaves:", salary.ExtraLeaves.ToString());
                DrawRow("Salary on Basic Hours:", salary.BasicSalary.ToString("C"));
                DrawRow("Salary on OT Hours:", salary.OTSalary.ToString("C"));
                DrawRow("Deduction on Extra Leaves:", salary.LeaveDeduction.ToString("C"));
                DrawRow("Service Fee:", salary.ServiceFee.ToString("C"));
                DrawRow("Total Salary:", salary.TotalSalary.ToString("C"), isBold: true);

                // Save PDF to Documents Folder
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(folderPath, $"Payroll_{salary.Month.Replace(" ", "_")}.pdf");

                document.Save(filePath);
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });

                MessageBox.Show("PDF generated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF:\n" + ex.Message);
            }
        }


        //------------------------------------------------------------Reques leave------------------------------------------------------------

        private void LoadLeaveDetails()
        {
            LeaveDetails leave = new LeaveDetails
            {
                LeavePerMonthSick = "12",
                LeavePerMonthCasual = "15",
                LeaveTakenSick = "3",
                LeaveTakenCasual = "5",
                RemainingSick = "9",
                RemainingCasual = "10",
                SelectedLeaveType = "Sick",
                SelectedLeaveDate = DateTime.Today,
                LeaveReason = ""
            };

            requestLeaveGrid.DataContext = leave; 
        }

        private void SubmitLeave_Click(object sender, RoutedEventArgs e)
        {
            LeaveDetails leave = requestLeaveGrid.DataContext as LeaveDetails;

            if (leave == null)
            {
                MessageBox.Show("Leave details not loaded.");
                return;
            }

            // Submit leave to database logic here
            Console.WriteLine($"Leave Request Submitted: {leave.SelectedLeaveType} on {leave.SelectedLeaveDate?.ToShortDateString()} for reason: {leave.LeaveReason}");

            MessageBox.Show("Leave submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);



            string leaveType = (cmbLeaveType.SelectedItem as ComboBoxItem)?.Content.ToString();
            Console.WriteLine($"Leave Type: {leaveType}");
            var repo = new AttendancePayrollRepository();
            Leave leaveRequest = new Leave
            {
                id = repo.GetNextRowId("RequestLeave"),
                employee_id = LogedEmployee.id,
                leave_type = leaveType,
                reason = txtReason.Text,
                dateRequested = leaveDatePicker.SelectedDate?.ToString("yyyy-MM-dd") // Fix: Use SelectedDate and null-conditional operator
            };
            repo.RequestLeave(leaveRequest);
        }




        // ----------------------------------------------------------------pending request button----------------------------------------------------------------

        private void acceptRequest(object sender, RoutedEventArgs e)
       {
            Console.WriteLine("accepted");
        }
        private void declineRequest(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("decline");
        }



    }

    //------------------------------------------------------------ DataBase GET SET ------------------------------------------------------------
    public class Member
    {
        public String Character { get; set; }
        public String Number { get; set; }
        public String Name { get; set; }
        public String Position { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public Brush BgColor { get; set; }

    }

    public class Request
    {
        public int No { get; set; }
        public String EmployeeName { get; set; }
        public String EmployeePosition { get; set; }
        public String LeaveDate { get; set; }
        public String LeaveType { get; set; }
        public String Reason { get; set; }
        public String State { get; set; }
    }

    // --------------------------employee databace info ------------------------

    public class EmployeeInfomation : INotifyPropertyChanged
    {
        private string casualLeave;
        private string sickLeave;
        private string annualLeave;
        private string presentDays;
        private string absentDays;
        private string lateDays;
        private string lastSalary;
        private string salaryMonth;
        private string performanceScore;
        private string lastReviewMonth;

        public string CasualLeave { get => casualLeave; set { casualLeave = value; OnPropertyChanged(); } }
        public string SickLeave { get => sickLeave; set { sickLeave = value; OnPropertyChanged(); } }
        public string AnnualLeave { get => annualLeave; set { annualLeave = value; OnPropertyChanged(); } }
        public string PresentDays { get => presentDays; set { presentDays = value; OnPropertyChanged(); } }
        public string AbsentDays { get => absentDays; set { absentDays = value; OnPropertyChanged(); } }
        public string LateDays { get => lateDays; set { lateDays = value; OnPropertyChanged(); } }
        public string LastSalary { get => lastSalary; set { lastSalary = value; OnPropertyChanged(); } }
        public string SalaryMonth { get => salaryMonth; set { salaryMonth = value; OnPropertyChanged(); } }
        public string PerformanceScore { get => performanceScore; set { performanceScore = value; OnPropertyChanged(); } }
        public string LastReviewMonth { get => lastReviewMonth; set { lastReviewMonth = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // -------------------------Salary Database Info-----------------------------------------
    public class SalaryDetails
    {
        public string Month { get; set; }
        public decimal HourRate { get; set; }
        public decimal ServiceFee { get; set; }
        public int ExtraLeaves { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal OTSalary { get; set; }
        public decimal LeaveDeduction { get; set; }
        public decimal TotalSalary { get; set; }
    }
    // -------------------------Reques leave Database Info-----------------------------------------
    //public class RequestLeaveViewModel : INotifyPropertyChanged
    //{
    //    private string leavePerMonthSick;
    //    private string leavePerMonthCasual;
    //    private string leaveTakenSick;
    //    private string leaveTakenCasual;
    //    private string remainingSick;
    //    private string remainingCasual;
    //    private string selectedLeaveType;
    //    private DateTime? selectedLeaveDate;
    //    private string leaveReason;

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    public string LeavePerMonthSick{get => leavePerMonthSick;set { leavePerMonthSick = value; OnPropertyChanged(nameof(LeavePerMonthSick)); }}
    //    public string LeavePerMonthCasual {get => leavePerMonthCasual;set { leavePerMonthCasual = value; OnPropertyChanged(nameof(LeavePerMonthCasual)); }}
    //    public string LeaveTakenSick{get => leaveTakenSick;set { leaveTakenSick = value; OnPropertyChanged(nameof(LeaveTakenSick)); }}
    //    public string LeaveTakenCasual{get => leaveTakenCasual;set { leaveTakenCasual = value; OnPropertyChanged(nameof(LeaveTakenCasual)); }}
    //    public string RemainingSick{get => remainingSick;set { remainingSick = value; OnPropertyChanged(nameof(RemainingSick)); }}
    //    public string RemainingCasual {get => remainingCasual;set { remainingCasual = value; OnPropertyChanged(nameof(RemainingCasual)); }}
    //    public string SelectedLeaveType {get => selectedLeaveType;set { selectedLeaveType = value; OnPropertyChanged(nameof(SelectedLeaveType)); } }
    //    public DateTime? SelectedLeaveDate{get => selectedLeaveDate;set { selectedLeaveDate = value; OnPropertyChanged(nameof(SelectedLeaveDate)); }}
    //    public string LeaveReason{get => leaveReason;set { leaveReason = value; OnPropertyChanged(nameof(LeaveReason)); }}
    //    private void OnPropertyChanged(string propertyName)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }


    public class LeaveDetails
    {
        public string LeavePerMonthSick { get; set; }
        public string LeavePerMonthCasual { get; set; }
        public string LeaveTakenSick { get; set; }
        public string LeaveTakenCasual { get; set; }
        public string RemainingSick { get; set; }
        public string RemainingCasual { get; set; }
        public string SelectedLeaveType { get; set; }
        public DateTime? SelectedLeaveDate { get; set; }
        public string LeaveReason { get; set; }
    }

}






