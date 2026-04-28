using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Threading;//Namespace for all ADO.NET SQL server classes. 

namespace DatabaseProgramming
{
 
    internal class Program
    {
        static void WriteToDb(string tableName, string inputs)
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            var query = $"Insert into {tableName} (Description) values('{inputs}')";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        const string STRCONNECTION = "Data Source=.\\SQLEXPRESS;Initial Catalog=TitanDb;Integrated Security=True;Encrypt=False";
        static void Main(string[] args)
        {
            var menu = File.ReadAllText("Menu.txt");//As the file is copied to the output dir, the app can read the file directly without any path information.
            var processing = true;
            do
            {
                Console.WriteLine(menu);
                string choice = Console.ReadLine();
                processing = processMenu(choice);
                Thread.Sleep(3000);
                Console.Clear();
            }while(processing);                                        
        }

        private static bool processMenu(string choice)
        {
            switch(choice)
            {
                case "1": handleAddOperation(); break;
                case "2": handleUpdateOperation(); break;
                case "3": handleDeleteOperation(); break;
                case "4": handleAddOperation(); break;
                default:
                    return false;
            }
            return true;
        }

        private static void handleDeleteOperation()
        {
            Console.WriteLine("Enter the Id of the Employee to delete");
            int id;
            if(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("not valid input, exiting the procedure");
                return;
            }
            try
            {
                deleteRecord(id);
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
        }

        private static void handleUpdateOperation()
        {
            Console.WriteLine("Enter the Id of the Employee to update");
            int id;
            if(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("not valid input, exiting the procedure");
                return;
            }
            Console.WriteLine("Enter the Name ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the salary");
            int salary;
            if(!int.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("not valid input, exiting the procedure");
                return;
            }
            try
            {
                updateRecord(id, name, address, salary);
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
        }

        private static void handleAddOperation()
        {
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the salary");
            int salary;
            if(!int.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("not valid input, exiting the procedure");
                return;
            }
            try
            {
                insertRecordDemo(name, address, salary);
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }

        private static void deleteRecord(int v)
        {
            var query = $"Delete From EMPLOYEE WHERE EMPID = " + v;
            var connection = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(query, connection);
            try
            {
                connection.Open();//connect to the database.
                var rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    Console.WriteLine("Record Deleted successfully");
                }
                else
                {
                    throw new Exception("Record not found to Delete");
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception genEx)
            {
                throw genEx;
            }
            finally
            {
                connection.Close();
            }
        }

        private static void updateRecord(int v1, string name, string address, int salary)
        {
            var query = $"Update Employee Set EmpName  = '{name}', EmpAddress = '{address}', EmpSalary = {salary} where EmpID = {v1}";
            var connection = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(query, connection);
            try
            {
                connection.Open();//connect to the database.
                var rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    Console.WriteLine("Record updated");
                }
                else
                {
                    throw new Exception("Record not found to update");
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception genEx)
            {
                throw genEx;
            }
            finally
            {
                connection.Close();
            }

        }

        private static List<(string, string , string)> readRecords()
        {
            List<(string, string, string)> data = new List<(string, string, string)> ();
            //query
            var query = "SELECT EmpName, EmpAddress, EmpSalary FROM Employee";
            //connection
            var connection = new SqlConnection(STRCONNECTION);
            //command
            var command = connection.CreateCommand();//Another way of created an initialized Command object
            command.CommandText = query;
            try
            {
                connection.Open(); //open
                var reader = command.ExecuteReader();//execute
                if(!reader.HasRows)
                {
                    Console.WriteLine("No rows available");
                    throw new Exception("No Records found");
                }
                while(reader.Read()) //read the data
                {
                    var values = (reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                    data.Add(values);
                }
                return data;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();//close
            }
        }

        /// <summary>
        /// Helper function to demo on inserting record from ADO.NET
        /// </summary>
        /// <exception cref="SqlException"></exception>
        /// <exception cref="Exception"></exception>
        private static void insertRecordDemo(string name, string address, int salary)
        {
            //write a query to insert a record
            var sqlStatement = $"INSERT INTO EMPLOYEE (EmpName, EmpAddress, EmpSalary) VALUES('{name}', '{address}', {salary})";
            var connection = new SqlConnection(STRCONNECTION);//CONNECTION STRING: Its the info about UR database to connect. ServerName, DbName, Credentials...

            var cmd = new SqlCommand(sqlStatement, connection);//Association of Connection with Command

            try
            {
                connection.Open();//Connects to the database..
                var rowsAffected = cmd.ExecuteNonQuery();//The SQL Statement is not select and does not return any data 
                if(rowsAffected > 0)
                {
                    Console.WriteLine("Insertion successfull");
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
