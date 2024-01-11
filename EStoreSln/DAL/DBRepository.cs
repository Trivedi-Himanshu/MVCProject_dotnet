using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BOL;
using MySql.Data.MySqlClient;


namespace DAL
{
    public class DBRepository
    {
        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"server=localhost; port=3306; user=root; password=root123; database=dotnet";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from employee";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["Id"].ToString());
                    string? firstName = reader["firstName"].ToString();
                    string? LastName = reader["LastName"].ToString();
                    string? email = reader["email"].ToString();
                    string? address = reader["address"].ToString();

                    Employee emp = new Employee();
                    emp.Id = id;
                    emp.Address = address;
                    emp.FirstName = firstName;
                    emp.LastName = LastName;
                    emp.Email = email;
                    employees.Add(emp);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }

            return employees;
        }

        public Employee GetById(int id)
        {
            Employee emp = new Employee();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"server=localhost; port=3306; user=root; password=root123; database=dotnet";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM employee where id=" + id;
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int empId = int.Parse(reader["id"].ToString());
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    string email = reader["email"].ToString();
                    string address = reader["address"].ToString();
                    emp.Id = empId;
                    emp.Email = email;
                    emp.Address = address;
                    emp.FirstName = firstName;
                    emp.LastName = lastName;
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return emp;
        }

        public void Insert(Employee emp)
        {
            Console.WriteLine("in insert method...");
            Console.WriteLine(emp.Id + "in insert method...");

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"server=localhost; port=3306; user=root; password=root123; database=dotnet";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            // cmd.CommandText = "insert into employee value (" + emp.Id + "," + emp.FirstName + "," + emp.LastName.ToString() + "," + emp.Email.ToString() + "," + emp.Address.ToString() + ")";
            Console.WriteLine("before insert ..");
            cmd.CommandText = "insert into employee values (" + emp.Id + ",'" + emp.FirstName + "','" + emp.LastName + "','" + emp.Email + "','" + emp.Address + "')";
            //cmd.CommandText = "insert into employee(id,firstName,lastName,email,address) values (@emp.Id, @emp.FirstName,@emp.LastName,@emp.email,@emp.address)";
            Console.WriteLine("after insert ..");
            try
            {
                con.Open();
                Console.WriteLine("in insert try block...");
                cmd.ExecuteNonQuery();
                Console.WriteLine("inserted successfully...!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void Delete(int id)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"server=localhost; port=3306; user=root; password=root123; database=dotnet";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete FROM employee where id=" + id;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("deleted successfully...!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}