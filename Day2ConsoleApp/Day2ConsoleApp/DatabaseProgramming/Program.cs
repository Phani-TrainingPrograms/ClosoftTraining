using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;//Namespace for all ADO.NET SQL server classes. 

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
            try
            {
                WriteToDb("ErrorInfo", "Trying to read Data");
                //todo: Modify this code to allow user to enter the values
                //insertRecordDemo("Ramesh", "Madurai", 50000);
                var data =  readRecords();
                foreach(var record in data)
                {
                    Console.WriteLine($"{record.Item1}, {record.Item2}, {record.Item3}");
                }
                //todo: Instead of tuple, Create a new class called Employee with EmpId...
                //popualte the objects with the data and return as List<Employee>
            }
            catch(SqlException ex)
            {
                WriteToDb("ErrorInfo", ex.Message);
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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
