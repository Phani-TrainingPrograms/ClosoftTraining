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
        const string UPDATE = "UPDATE PRODUCT SET ProductName = @name, ProductCost = @price, ProductStock = @stock where ProductId = @id";
        const string GETALL = "SELECT * FROM PRODUCT";
        const string DELETE = "DELETE FRom PRODUCT WHERE PRODUCTID = @id";

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
            throw new NotImplementedException();
        }

        public void UpdateProduct(int id, string name, double price, int stock)
        {
            throw new NotImplementedException();
        }
    }
}
