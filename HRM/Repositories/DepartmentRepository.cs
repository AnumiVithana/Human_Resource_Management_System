using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Model;
using System.Data.SqlClient;
using HRM.models;



namespace HRM.Repositories
{
    public class DepartmentRepository
    {
        private readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Initial Catalog=hrmDB;Integrated Security=True;TrustServerCertificate=True;";

        public void CreateDepartment(Department department)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Department (DepartmentId, Name, EmployeeCount, Email, Contact)" +
                        "VALUES (@DepartmentId, @Name, @EmployeeCount, @Email, @Contact)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@DepartmentId", department.DepartmentId);
                        command.Parameters.AddWithValue("@Name", department.Name);
                        command.Parameters.AddWithValue("@EmployeeCount", department.EmployeeCount);
                        command.Parameters.AddWithValue("@Email", department.Email);
                        command.Parameters.AddWithValue("@Contact", department.Contact);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating department: " + ex.Message);
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
                return 2; // Default to 1 if there's an error
            }
        }


        public List<Department> GetDepartment()
        {
            var departments = new List<Department>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //string sql = "SELECT * FROM employees ORDER BY id DESC";
                    string sql = "SELECT DepartmentID, Name, EmployeeCount, Email, Contact FROM Department ORDER BY EmployeeID DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())

                            while (reader.Read())
                            {
                                var department = new Department {

                                    DepartmentId = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    EmployeeCount = reader.GetInt32(2),
                                    Email = reader.GetString(3),
                                    Contact = reader.GetString(4)

                                };
                                departments.Add(department);

                            }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return departments;
        }



        public int GetNextEmployId()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT ISNULL(MAX(id), 0) + 1 FROM Department"; // Get the next ID
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
