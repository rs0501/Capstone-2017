﻿using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeAccessor
    {
        /// <summary>
        /// Daniel Brown 
        /// Created 02/08/2017
        /// 
        /// Retrieve a single employee from the database
        /// </summary>
        /// <param name="employeeID">The employee ID of the employee to be retrieved</param>
        /// <returns>An employee object</returns>
        public static Employee RetrieveEmployee(int employeeID)
        {

            Employee employee = null;

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_employee";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            cmd.Parameters["@EmployeeID"].Value = employeeID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    employee = new Employee()
                    {
                        EmployeeId = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        Salary = reader.GetDecimal(3),
                        Active = reader.GetBoolean(4),
                        DateOfBirth = reader.GetDateTime(5)
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return employee;

        }

        /// <summary>
        /// Daniel Brown
        /// Created 02/08/2017
        /// 
        /// Retrieve a list of all employees
        /// </summary>
        /// <returns>List of Employee Objects</returns>
        public static List<Employee> RetrieveEmployeeList()
        {
            List<Employee> employees = new List<Employee>();

            var conn = DBConnection.GetConnection();
            var cmdText = @"sp_retrieve_employeelist";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee()
                        {
                            EmployeeId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Salary = reader.GetDecimal(3),
                            Active = reader.GetBoolean(4),
                            DateOfBirth = reader.GetDateTime(5)
                        });
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return employees;

        }
        
        
        /// <summary>
        /// Ariel Sigo
        /// Created 2017/02/07
        /// </summary>
        /// <param name="Employee_ID"></param>
        /// <param name="oldUser_ID"></param>
        /// <param name="newUser_ID"></param>
        /// <param name="oldSalary"></param>
        /// <param name="newSalary"></param>
        /// <param name="oldActive"></param>
        /// <param name="newActive"></param>
        /// <param name="oldDate_Of_Birth"></param>
        /// <param name="newDate_Of_Birth"></param>
        /// <returns>returns count of rows affected of updated employees</returns>
        public static int UpdateEmployee(int Employee_ID, int oldUser_ID, int newUser_ID, decimal oldSalary, decimal newSalary, bool oldActive, bool newActive, DateTime oldDate_Of_Birth, DateTime newDate_Of_Birth)
        {
            var count = 0;

            // sql connection object
            var conn = DBConnection.GetConnection();

            // command text
            var cmdText = @"sp_update_employee";

            // create a command object
            var cmd = new SqlCommand(cmdText, conn);

            //set command type if needed
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters
            cmd.Parameters.Add("@Employee_ID", SqlDbType.Int);
            cmd.Parameters.Add("@OldUser_ID", SqlDbType.Int);
            cmd.Parameters.Add("@NewUser_ID", SqlDbType.Int);
            cmd.Parameters.Add("@OldSalary", SqlDbType.Money);
            cmd.Parameters.Add("@NewSalary", SqlDbType.Money);
            cmd.Parameters.Add("@OldActive", SqlDbType.Bit);
            cmd.Parameters.Add("@NewActive", SqlDbType.Bit);
            cmd.Parameters.Add("@OldDate_Of_Birth", SqlDbType.Date);
            cmd.Parameters.Add("@NewDate_Of_Birth", SqlDbType.Date);

            // set parameter values
            cmd.Parameters["@OldUser_ID"].Value = oldUser_ID;
            cmd.Parameters["@NewUser_ID"].Value = newUser_ID;
            cmd.Parameters["@OldSalary"].Value = oldSalary;
            cmd.Parameters["@NewSalary"].Value = newSalary;
            cmd.Parameters["@OldActive"].Value = oldActive;
            cmd.Parameters["@NewActive"].Value = newActive;
            cmd.Parameters["@OldDate_Of_Birth"].Value = oldDate_Of_Birth;
            cmd.Parameters["@NewDate_Of_Birth"].Value = newDate_Of_Birth;

            try
            {
                // open the connection
                conn.Open();

                // let the execution begin!
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close(); // good housekeeping approved!
            }
            return count;
        }



    }
}
