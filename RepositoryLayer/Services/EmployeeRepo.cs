using CommonLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace RepositoryLayer.Services
{
    public class EmployeeRepo : IEmployeeRepo
    {
        List<Employee> employeePayList = new List<Employee>();

        //SQL Connection
        SqlConnection con = new SqlConnection();
        readonly string connectionString;

        private readonly IConfiguration _configuration;
        public EmployeeRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("EmployeeDbCs");
            con.ConnectionString = connectionString;

        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                this.con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.EmployeeName = rdr["EmployeeName"].ToString();
                    employee.ProfileImg = rdr["ProfileImg"].ToString();
                    employee.Gender = Convert.ToChar(rdr["Gender"]);
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToDecimal(rdr["Salary"]);
//                    employee.Salary = Convert.ToInt64(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Notes = rdr["Notes"].ToString();
                    employeePayList.Add(employee);

                    //=-===========================
/*                    EmployeeID = Convert.ToInt32(rdr["EmployeeID"]),
                    EmployeeName = rdr["EmployeeName"].ToString(),
                    ProfileImg = rdr["ProfileImg"].ToString(),
                    Gender = Convert.ToChar(rdr["Gender"]),
                    Department = rdr["Department"].ToString(),
                    Salary = Convert.ToDecimal(rdr["Salary"]),
                    StartDate = Convert.ToDateTime(rdr["StartDate"]),
                    Notes = rdr["Notes"].ToString()
*/                    //=-===========================
                }
                return employeePayList;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.con.Close();
            }
        }

        public Employee AddEmployee(Employee employee)
        {
            /*
            CREATE PROCEDURE sp_InsertEmployee
                @EmployeeName NVARCHAR(100),
                @ProfileImg NVARCHAR(100),
                @Gender CHAR,
                @Department NVARCHAR(100),
                @Salary DECIMAL(10,2),
                @StartDate DATE,
                @Notes TEXT
            AS
            BEGIN
                INSERT INTO Employees (EmployeeName, ProfileImg, Gender, Department, Salary, StartDate, Notes)
                VALUES (@EmployeeName, @ProfileImg, @Gender, @Department, @Salary, @StartDate, @Notes);
            END;
            */
            try
            {
                SqlCommand cmd = new SqlCommand("sp_InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@ProfileImg", employee.ProfileImg);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                con.Open();
                cmd.ExecuteNonQuery();

                return employee;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.con.Close();
            }

        }

        public Employee UpdateEmployee(Employee employee)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID); 
                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@ProfileImg", employee.ProfileImg);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                con.Open();
                cmd.ExecuteNonQuery();

                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", id);
                con.Open();
                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                    Console.WriteLine("Employee Deleted");
                else
                    Console.WriteLine("Failed to Delete Employee");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                Employee employee = new Employee();

                SqlCommand cmd = new SqlCommand("sp_GetEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", id);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.EmployeeName = rdr["EmployeeName"].ToString();
                    employee.ProfileImg = rdr["ProfileImg"].ToString();
                    employee.Gender = Convert.ToChar(rdr["Gender"]);
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToDecimal(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Notes = rdr["Notes"].ToString();
                }

                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /*        public Employee UpdateEmployee(Employee employee)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                        cmd.Parameters.AddWithValue("@ProfileImg", employee.ProfileImg);
                        cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                        cmd.Parameters.AddWithValue("@Department", employee.Department);
                        cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                        cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                        cmd.Parameters.AddWithValue("@Notes", employee.Notes);
                        this.con.Open();
                        cmd.ExecuteNonQuery();

                        return employee;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        this.con.Close();
                    }

                }
        */
        /*        public void DeleteEmployee(int id)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id", id);
                        this.con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                            Console.WriteLine("Delete Employee");
                        else
                            Console.WriteLine("Not Delete Employee");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        this.con.Close();
                    }
                }
        */
        /*        public Employee GetEmployeeById(int id)
                {
                    try
                    {
                        Employee employee = new Employee();
                        string query = "Select * from tableEmployee where id=" + id;
                        SqlCommand cmd = new SqlCommand(query, con);
                        this.con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            employee.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                            employee.EmployeeName = rdr["EmployeeName"].ToString();
                            employee.ProfileImg = rdr["ProfileImg"].ToString();
                            employee.Gender = Convert.ToChar(rdr["Gender"]);
                            employee.Department = rdr["Department"].ToString();
        //                    employee.Salary = Convert.ToInt64(rdr["Salary"]);
                            employee.Salary = Convert.ToDecimal(rdr["Salary"]);
                            employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                            employee.Notes = rdr["Notes"].ToString();
                        }

                        return employee;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        this.con.Close();
                    }

                }
        */
    }
}
