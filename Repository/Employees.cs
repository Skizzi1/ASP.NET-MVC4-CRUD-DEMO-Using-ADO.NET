using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.Configuration;
using System.Data.SqlClient;
using MVC_Demo.Models;
using MVC_Demo.Interface;

namespace MVC_Demo.Repository
{
    public class Employees : IEmployee
    {
        private static string conString = WebConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        public void Create(Employee e)
        {
            SqlConnection con = new SqlConnection(conString.ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Employee(Guid, Employee, Salary, JobTitle) VALUES(@Guid, @Employee, @Salary, @JobTitle)";
            cmd.Parameters.AddWithValue("@Guid", e.guid);
            cmd.Parameters.AddWithValue("@Employee", e.employee);
            cmd.Parameters.AddWithValue("@Salary", e.salary);
            cmd.Parameters.AddWithValue("@JobTitle", e.jobTitle);

            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Guid id)
        {
            SqlConnection con = new SqlConnection(conString.ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Employee WHERE Guid=@Guid";
            cmd.Parameters.AddWithValue("@Guid", id);

            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(Employee e)
        {
            SqlConnection con = new SqlConnection(conString.ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "UPDATE Employee SET Employee=@Employee, Salary=@Salary, JobTitle=@JobTitle WHERE Guid=@Guid";
            cmd.Parameters.AddWithValue("@Guid", e.guid );
            cmd.Parameters.AddWithValue("@Employee", e.employee);
            cmd.Parameters.AddWithValue("@Salary", e.salary);
            cmd.Parameters.AddWithValue("@JobTitle", e.jobTitle);

            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Employee> Read()
        {

            List<Employee> employeeList = new List<Employee>();
            SqlConnection con = new SqlConnection(conString.ToString());
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Employee";


            using (con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
             
                while (reader.Read())
                {
                    Employee e = new Employee();

                    e.id = Convert.ToInt16(reader["id"]);
                    e.guid = Guid.Parse(reader["Guid"].ToString());
                    e.employee = reader["Employee"].ToString();
                    e.salary = Convert.ToDecimal(reader["Salary"]);
                    e.jobTitle = reader["JobTitle"].ToString();

                    employeeList.Add(e);
                }
            }

            return employeeList;
        }


    }
}