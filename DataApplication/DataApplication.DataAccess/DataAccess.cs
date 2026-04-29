using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace DataApplication.DataAccess
{
    public interface IDataAccess
    {
        void AddNewProduct(int id, string name, double price, int stock);
        void UpdateProduct(int id, string name, double price, int stock);

        void DeleteProduct(int id);
        DataTable GetAllProducts();
    }

    public class DataAccessComponent : IDataAccess
    {
        #region CONSTANTS
        const string INSERT = "INSERT INTO PRODUCT VALUES(@id, @name, @price, @stock)";
        const string UPDATE = "UPDATE PRODUCT SET ProductName = @name, ProductCost = @price, ProductStock = @stock where Id = @id";
        const string GETALL = "SELECT Id, PRODUCTNAME, PRODUCTCOST, PRODUCTSTOCK FROM PRODUCT";
        const string DELETE = "DELETE FRom PRODUCT WHERE Id = @id";

        static readonly string CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        #endregion

        public void AddNewProduct(int id, string name, double price, int stock)
        {
            var connection = new SqlConnection(CONNECTIONSTRING);
            var cmd = new SqlCommand(INSERT, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@stock", stock);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllProducts()
        {
            //connect to the db
            using(var connection = new SqlConnection(CONNECTIONSTRING))//automatic memory management shall happen and internally ensures that once the object goes out of scope, it will be deleted by Garbage collector of .NET. It shall internally call Dispose method which ensures any unmanaged code for releasing the resources will be done.  
            {
                using(var cmd = new SqlCommand(GETALL, connection))
                {
                    try
                    {
                        connection.Open();
                        var reader = cmd.ExecuteReader();//It is a select statement and expects data to be read.
                        DataTable table = new DataTable("ListOfProducts");
                        table.Load(reader);//Reader will internally read all the data and store it into a Table of records
                        return table;
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            //execute the query
            //Convert the reader to a DataTable
            //return the table
            //handle exceptions. 
        }

        public void UpdateProduct(int id, string name, double price, int stock)
        {
            using(var connection = new SqlConnection(CONNECTIONSTRING))
            {
                using(var cmd = new SqlCommand(UPDATE, connection)) 
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    try
                    {
                        connection.Open();
                        var rowsAffected = cmd.ExecuteNonQuery();
                        if(rowsAffected <= 0)
                        {
                            throw new Exception("Updation has failed");
                        }
                    }
                    catch(Exception ex)
                    {
                        //Log the exceptions here itself if required.
                        throw ex;
                    }

                }
            }
        }
    }
}
