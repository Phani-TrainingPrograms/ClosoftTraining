using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Create a project of ClassLibrary(.NET Framework) and implement the class in it. 
namespace DataApplication.Models
{
    //Models represent real world Entity
    public class Product
    {
        public int ProductId { get; set; }
        public string  ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
    }
}
