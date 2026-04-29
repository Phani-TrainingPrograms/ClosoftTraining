using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataApplication.Models;
using DataApplication.Services;
//.NET 4.8 does not have DI  of its own. However, .NET 8 comes with DI patterns. 
namespace DataApplication.ConsoleUI
{
    internal class Program
    {
        private static IDataService _service;

        private static void Initialise()
        {
            _service = new DataService();
        }
        static void Main(string[] args)
        {
            Initialise();
            var menu = File.ReadAllText("Menu.txt");//As the file is copied to the output dir, the app can read the file directly without any path information.
            var processing = true;
            do
            {
                Console.WriteLine(menu);
                string choice = Console.ReadLine();
                processing = ProcessMenu(choice);
                //Thread.Sleep(3000);
                //Console.Clear();
            } while(processing);
        }

        private static bool ProcessMenu(string choice)
        {
            switch(choice)
            {
                case "1": handleAddOperation(); break;
                case "2": handleUpdateOperation(); break;
                case "3": handleDeleteOperation(); break;
                case "4": handleReadOperation(); break;
                default:
                    return false;
            }
            return true;
        }

        //UI->Service->DAL->DB
        private static void handleReadOperation()
        {
            try
            {//App in debug mode stops here to allow user to execute the program step by step. Press F10 to move to next line or press F11 to move into a function if the line points to a function. 
                _service.GetAllProducts().ForEach(product =>
                {
                    Console.WriteLine($"ProductId: {product.ProductId}: ProductName : {product.ProductName} costs {product.ProductPrice:C}");
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error occured while extracting records");
                Console.WriteLine(ex.Message);
            }
        }

        private static void handleDeleteOperation()
        {
            Console.WriteLine("Enter the Id of the Product to delete");
            int id;
            if(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("not valid input, exiting the procedure");
                return;
            }
            try
            {
                _service.DeleteProduct(id);
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
        }

        private static Product TakeInputs()
        {
            Console.WriteLine("Enter the Id of the Product");
            int id;
            if(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("not valid input, exiting the procedure");
                throw new Exception("Invalid Inputs for a number");
            }
            Console.WriteLine("Enter the product Name ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Cost");
            double cost = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Stock count");
            int count;
            if(!int.TryParse(Console.ReadLine(), out count))
            {
                Console.WriteLine("not valid input, exiting the procedure");
                throw new Exception("Invalid Inputs for a number");
            }
            return new Product { ProductId = id, ProductName = name, ProductPrice = cost, ProductStock = count };
        }
        private static void handleUpdateOperation()
        {
            var product = TakeInputs();
            try
            {
                _service.UpdateProduct(product);
                Console.WriteLine("Product details updated successfully");
            }
            catch(Exception e) 
            { 
                Console.WriteLine(e.Message); 
            }
        }

        private static void handleAddOperation()
        {
            try
            {
            var newProduct = TakeInputs();
            if(newProduct == null){
                return;
            }
            
                _service.AddNewProduct(newProduct);
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
