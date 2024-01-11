using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using BOL;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Crmf;


namespace DAL
{
    public class DBDisconnect
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
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(da);

                da.Fill(ds);
                DataTable dtEmployees = ds.Tables[0];
                DataRowCollection rows = dtEmployees.Rows;

                foreach (DataRow row in rows)
                {
                    int id = int.Parse(row["id"].ToString()); 
                    string? firstName = row["firstName"].ToString();
                    string? lastName = row["lastName"].ToString();
                    string? email = row["email"].ToString();
                    string? address = row["address"].ToString();

                    Employee emp = new Employee();
                    emp.Id = id;
                    emp.FirstName = firstName;
                    emp.LastName = lastName;
                    emp.Address = address;
                    emp.Email = email;
                    employees.Add(emp);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("In the Db DIsconnect#***##################################################################");
            return employees;
        }

        public Employee GetById(int id)
        {
            Employee emp = new Employee();
            bool status = false;
            //Insert disconnected code to be written
            List<Employee> employees = new List<Employee>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"server=localhost; port=3306; user=root; password=root123; database=dotnet";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from employee";
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataTable dtEmployees = ds.Tables[0];
                DataRowCollection rows = dtEmployees.Rows;
                DataRow[] foundRows = dtEmployees.Select("Id =" + id); //*******
                Console.WriteLine("Found " + foundRows.Length);
                DataRow theRow = foundRows[0];
                Console.WriteLine(theRow["id"].ToString() + " " + theRow["firstName"].ToString());
                emp.Id = int.Parse(theRow["id"].ToString());
                emp.FirstName = theRow["firstName"].ToString();
                emp.LastName = theRow["lastName"].ToString();
                emp.Address = theRow["address"].ToString();
                emp.Email = theRow["email"].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return emp;
        }

        public bool Insert(Employee emp)
        {
            bool status = false;
            //Insert disconnected code to be written
            List<Employee> employees = new List<Employee>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"server=localhost; port=3306; user=root; password=root123; database=dotnet";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from employee";
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataTable dtEmployees = ds.Tables[0];
                DataRowCollection rows = dtEmployees.Rows;
                DataRow row = dtEmployees.NewRow();
                row["firstName"] = emp.FirstName;
                row["lastName"] = emp.LastName;
                row["email"] = emp.Email;
                row["address"] = emp.Address;
                rows.Add(row);
                da.Update(ds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return status;
        }
        public void Delete(int id)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"server = localhost;port = 3306 ; user = root: password = root123; database = dotnet";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from employee";
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataTable dtEmployees = ds.Tables[0];
                DataRowCollection rows = dtEmployees.Rows;
                DataRow[] foundRow = dtEmployees.Select("Id = " + id);
                DataRow deletableRow = foundRow[0];
                rows.Remove(deletableRow);
                da.Update(ds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void update(int id)
        {

            Console.WriteLine(" ***************************************");
            Employee emp = new Employee();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"server = localhost ; user  = root ;password = root123 ; port = 3306 ;database = dotnet ";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from employee";
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataTable empTable = ds.Tables[0];
                DataRowCollection rows = empTable.Rows;

                DataColumn[] keycolumn = new DataColumn[1];
                keycolumn[0] = empTable.Columns["id"];
                empTable.PrimaryKey = keycolumn;


                // DataRow[] updatableRow = empTable.Select("Id = " + id);


                DataRow row = rows.Find(emp.Id);
                row["firstName"] = emp.FirstName;
                row["lastName"] = emp.LastName;
                row["email"] = emp.Email;
                row["address"] = emp.Address;
                rows.Add(row);


                Console.WriteLine(rows.Find(rows) + " ***************************************");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }

}