using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApplication.Services
{
    using DataApplication.DataAccess;
    using DataApplication.Models;
    public interface IDataService
    {
        void AddNewProduct(Product product);
        void UpdateProduct(Product updatingProduct);
        void DeleteProduct(int id);
        List<Product> GetAllProducts();
    }

    public class DataService : IDataService
    {
        private readonly IDataAccess dataAccess = new DataAccessComponent();
        
        public void AddNewProduct(Product product)
        {
            //Handle all the business requirements here. 
            dataAccess.AddNewProduct(product.ProductId, product.ProductName, product.ProductPrice, product.ProductStock);
        }

        public void DeleteProduct(int id)
        {
            dataAccess.DeleteProduct(id);
        }

        public List<Product> GetAllProducts()
        {
            var records = new List<Product>();
            var table = dataAccess.GetAllProducts();
            foreach(DataRow row in table.Rows)
            {
                var product = new Product();
                product.ProductId = Convert.ToInt32(row[0]);
                product.ProductName = Convert.ToString(row[1]);
                product.ProductPrice = Convert.ToDouble(row[2]);
                product.ProductStock = Convert.ToInt32(row[3]);
                records.Add(product);
            }
            return records;
        }

        public void UpdateProduct(Product updatingProduct)
        {
            dataAccess.UpdateProduct(updatingProduct.ProductId, updatingProduct.ProductName, updatingProduct.ProductPrice, updatingProduct.ProductStock);
        }
    }
}
