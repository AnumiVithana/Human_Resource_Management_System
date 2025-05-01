using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Model;


namespace HRM.Repositories
{
    public class AttendancePayrollRepository
    {
        private readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Initial Catalog=hrmDB;Integrated Security=True;TrustServerCertificate=True;";


        public void CreateAttendancerow(Attendance attendance)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO attendance (id ,Date, employee_id, CheckInTime, CheckOutTime, WorkedHours, Description)"+ 
                        "VALUES (@id, @date, @employeeId, @checkInTime, @checkOutTime, @workedHovers, @description)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", attendance.id);
                        command.Parameters.AddWithValue("@date", attendance.date);
                        command.Parameters.AddWithValue("@employeeId", attendance.employeeId);
                        command.Parameters.AddWithValue("@checkInTime", attendance.checkInTime);
                        command.Parameters.AddWithValue("@checkOutTime", attendance.checkOutTime);
                        command.Parameters.AddWithValue("@workedHovers", attendance.workedHovers);
                        command.Parameters.AddWithValue("@description", attendance.description);
                        
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating attendance row: " + ex.Message);
            }


        }

        public int GetNextRowId()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT ISNULL(MAX(id), 0) + 1 FROM Attendance"; // Get the next ID
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                return 1; // Default to 1 if there's an error
            }
        }

    }
}
