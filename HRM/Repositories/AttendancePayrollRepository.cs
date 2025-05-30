﻿using System;
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
                    string sql = "INSERT INTO attendance (id ,Date, employee_id, CheckInTime, CheckOutTime, WorkedHours, Description)" +
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

        public int GetNextRowId(string tableName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = $"SELECT ISNULL(MAX(id), 0) + 1 FROM {tableName}"; // Use string interpolation to insert table name
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

        public void RequestLeave(Leave leave)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO RequestLeave (Id, EmployeeId, LeaveType, Reason, DateRequested) " +
                        "VALUES (@id, @employeeId, @leaveType, @reason, @dateRequested)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", leave.id);
                        command.Parameters.AddWithValue("@employeeId", leave.employee_id);
                        command.Parameters.AddWithValue("@leaveType", leave.leave_type);
                        command.Parameters.AddWithValue("@reason", leave.reason);
                        command.Parameters.AddWithValue("@dateRequested", leave.dateRequested);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error requesting leave: " + ex.Message);
            }
        }

        public List<Leave> GetLeaves()
        {
            var leaves = new List<Leave>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM RequestLeave ORDER BY id DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var leave = new Leave
                                {
                                    id = reader.GetInt32(0),
                                    employee_id = reader.GetInt32(1),
                                    leave_type = reader.GetString(2),
                                    reason = reader.GetString(3),
                                    status = null,
                                    dateRequested = reader.GetString(5)
                                };
                                leaves.Add(leave);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving leaves: " + ex.Message);
            }
            return leaves;
        }

        public void UpdateRequestState(int RequestId , string state)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE RequestLeave SET Status=@status WHERE Id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", RequestId);
                        command.Parameters.AddWithValue("status", state);
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
}
