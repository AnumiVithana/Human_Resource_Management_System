using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using HRM.models;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace HRM.Repositories
{
    public class EmployRepository
    {
        private readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Initial Catalog=hrmDB;Integrated Security=True;TrustServerCertificate=True;";
        //copy this from database -> properties -> connectionString

        //this method allow us to read the employees from the datadase
        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //string sql = "SELECT * FROM employees ORDER BY id DESC";
                    string sql = "SELECT id, first_name, last_name, pw_hash, department, position, contact_no, email , dob FROM employees ORDER BY id DESC";


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())

                            while (reader.Read())
                            {
                                Employee employ = new Employee();
                                employ.id = reader.GetInt32(0);
                                employ.first_name = reader.GetString(1);
                                employ.last_name = reader.GetString(2);
                                employ.pw_hash = reader.GetString(3);
                                employ.department = reader.GetString(4);
                                employ.position = reader.GetString(5);
                                employ.contact_no = reader.GetString(6);
                                employ.email = reader.GetString(7);
                                employ.dob = reader.GetString(8);

                                employees.Add(employ);

                            }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return employees;
        }

        //this method allow us to read a employ by his id
        //public Employees? GetEmploy(string id) this is the correct line 

        public Employee GetEmploy(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM employees WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                            if (reader.Read())
                            {
                                Employee employ = new Employee();
                                employ.id = reader.GetInt32(0);
                                employ.first_name = reader.GetString(1);
                                employ.last_name = reader.GetString(2);
                                employ.pw_hash = reader.GetString(3);
                                employ.department = reader.GetString(4);
                                employ.position = reader.GetString(5);
                                employ.contact_no = reader.GetString(6);
                                employ.email = reader.GetString(7);
                                employ.dob = reader.GetString(8);

                                return employ;

                            }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return null;
        }

        //this method will create new employ and add him to our db
        public void CreateEmploy(Employee employ)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO employees " +
                                 "(id, first_name, last_name, pw_hash, department,  position, contact_no , email, dob)" +
                                 "VALUES (@id, @first_name, @last_name, @pw_hash, @department,  @position, @contact_no , @email, @dob);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", employ.id);
                        command.Parameters.AddWithValue("@first_name", employ.first_name);
                        command.Parameters.AddWithValue("@last_name", employ.last_name);
                        command.Parameters.AddWithValue("@pw_hash", employ.pw_hash);
                        command.Parameters.AddWithValue("@department", employ.department);
                        command.Parameters.AddWithValue("@position", employ.position);
                        command.Parameters.AddWithValue("@contact_no", employ.contact_no);
                        command.Parameters.AddWithValue("@email", employ.email);
                        command.Parameters.AddWithValue("@dob", employ.dob);


                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }


        //this method will update Employ data

        //public void UpdateEmploy(Employee employ)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            string sql = "UPDATE employees " +
        //                          "SET first_name=@first_name, last_name=@last_name, pw_hast=@pw_hash" +
        //                          "department=@department, position=@position, contact_no=@contact_no" +
        //                          "email=@email, dob=@dob" +
        //                          "WHERE id=@id";

        //            using (SqlCommand command = new SqlCommand(sql, connection))
        //            {
        //                command.Parameters.AddWithValue("@id", employ.id);
        //                command.Parameters.AddWithValue("@first_name", employ.first_name);
        //                command.Parameters.AddWithValue("@last_name", employ.last_name);
        //                command.Parameters.AddWithValue("@pw_hash", employ.pw_hash);
        //                command.Parameters.AddWithValue("@department", employ.department);
        //                command.Parameters.AddWithValue("@position", employ.position);
        //                command.Parameters.AddWithValue("@contact_no", employ.contact_no);
        //                command.Parameters.AddWithValue("@email", employ.email);
        //                command.Parameters.AddWithValue("@dob", employ.dob);

        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception: " + ex.ToString());
        //    }

        //}

        public void UpdateEmploy(Employee employ)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE employees " +
                                 "SET first_name=@first_name, last_name=@last_name, pw_hash=@pw_hash, " +
                                 "department=@department, position=@position, contact_no=@contact_no, " +
                                 "email=@email, dob=@dob " +
                                 "WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", employ.id);
                        command.Parameters.AddWithValue("@first_name", employ.first_name);
                        command.Parameters.AddWithValue("@last_name", employ.last_name);
                        command.Parameters.AddWithValue("@pw_hash", employ.pw_hash);
                        command.Parameters.AddWithValue("@department", employ.department);
                        command.Parameters.AddWithValue("@position", employ.position);
                        command.Parameters.AddWithValue("@contact_no", employ.contact_no);
                        command.Parameters.AddWithValue("@email", employ.email);
                        command.Parameters.AddWithValue("@dob", employ.dob);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                throw; // Rethrow the exception to allow the calling code to handle it
            }
        }

        public void ResetPassword(string id , string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE employees SET pw_hash=@pw_hash WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@pw_hash", password);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        public void DeleteEmploy(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM employees WHERE id=@id"; // Corrected SQL command and parameter
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id); // Correct parameter placeholder

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                throw; // Rethrow the exception to allow the calling code to handle it
            }
        }

        public bool SignInEmplyee(string userName, string password)
        {
            string[] parts = userName.Split(' ');

            string firstName = parts[0].ToLower();
            string lastName = parts.Length > 1 ? parts[1].ToLower() : "";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM employees WHERE first_name=@firstName AND last_name=@lastName AND pw_hash=@pw_hash";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@pw_hash", password);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            return reader.HasRows;  // ✅ returns true if a matching row exists
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return false; // Ensure a return value for all code paths
        }


        public Employee GetEmployeeByName(string userName, string password)
        {
            string[] parts = userName.Split(' ');

            string firstName = parts[0].ToLower();
            string lastName = parts.Length > 1 ? parts[1].ToLower() : "";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM employees WHERE first_name=@firstName AND last_name=@lastName AND pw_hash=@pw_hash";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@pw_hash", password);
                        using (SqlDataReader reader = command.ExecuteReader())
                            if (reader.Read())
                            {
                                Employee employ = new Employee();
                                employ.id = reader.GetInt32(0);
                                employ.first_name = reader.GetString(1);
                                employ.last_name = reader.GetString(2);
                                employ.pw_hash = reader.GetString(3);
                                employ.department = reader.GetString(4);
                                employ.position = reader.GetString(5);
                                employ.contact_no = reader.GetString(6);
                                employ.email = reader.GetString(7);
                                employ.dob = reader.GetString(8);

                                return employ;

                            }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return null;
        }





        public int GetNextEmployId()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT ISNULL(MAX(id), 0) + 1 FROM employees"; // Get the next ID
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
