//OOP is a paradiam of developing advanced software that is based on the concept of objects.
//An object is an instance of a User defined type called Class. 
//A Class is a composite data type that contains data members and functions that are used to manipulate the data members. 
//With the class, U get OOP features like Inheritance, Polymorphism, Encapsulation and Abstraction. 
//A Class is created to represent a Real world Entity.
//If U R developing an Employee Management Software, Employee in UR program represents a Real World Employee. 
//Classes in real world shall be of multiple kinds: Entity classes that represent real world entities and usually contain properties only in them. Repository classes are classes that perform CRUD Operations(insert, delete, update and Read) on the data. 
//Service classes that performs some business logic on the data. Service classes are also used to call External APIs and perform some operations on the data received from the API.
//Application Programming Interfaces (API) are a set of functions that are used without worrying on its implementation. API's are used to call external services and get the data from them.


using System;

namespace AdvancedProgramming
{
    //Entity class.
    class Employee
    {
        //members of a class are fields, properties , methods and events.
        //fields are variables that are declared in a class.
        //Properties are accessors to those fields. Mostly fields are private to the class.
        //Functions are called methods of a class that are used to manipulate the data(fields) of the class.
        public int EmpID { get; set; } //properties. 
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public int EmpSalary { get; set; }
    }

    //Repo class:
    class EmployeeRepository
    {
        private Employee[] employees  = new Employee[100]; //array to hold the employee objects. This is a simple implementation. In real world, we use databases to store the data.
        //Arrays are fixed in size. Once U create the array it cannot be altered. U have to recreate the array to alter its size. In real world, we use collections like List<T> that are dynamic in size.
        public void AddNewEmployee(Employee emp)
        {
            Console.WriteLine("Employee added to the server");
        }

        public void DeleteEmployee(int empID)
        {
            Console.WriteLine("Employee deleted from the server");
        }   

        public void UpdateEmployee(Employee emp)
        {
            Console.WriteLine("Employee updated into the server");
        }   

        public void GetEmployee(int empID)
        {
            Console.WriteLine("Employee fetched from the server");
        }

        public Employee[] GetAllEmployees()
        {
            Console.WriteLine("All Employees are fetched from the server");
            return employees;
        }
    }
    internal class Program
    {
        static EmployeeRepository repo = new EmployeeRepository();//object of Repo class. 
        static int DisplayMenu()
        {
            Console.WriteLine("EMPLOYEE MANAGEMENT MENU");
            Console.WriteLine("Press 1 to add Employee");
            Console.WriteLine("Press 2 to find Employee");
            Console.WriteLine("Press 3 to update Employee");
            Console.WriteLine("Press 4 to delete Employee");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static bool processMenu()
        {
            var choice = DisplayMenu();
            switch(choice)
            {
                case 1:
                    handleAddEmployee();
                    return true;
                case 2:
                case 3:
                case 4:
                    return true;
                default:
                    return false;
            }
        }

        private static void handleAddEmployee()
        {
            var emp = new Employee();
            Console.WriteLine("Enter the Id");
            emp.EmpID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Name");
            emp.EmpName = Console.ReadLine();
            Console.WriteLine("Enter the Salary");
            emp.EmpSalary = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Address City");
            emp.EmpAddress = Console.ReadLine();
            repo.AddNewEmployee(emp);
            
            Console.WriteLine("Employee added successfully");
        }

        static void Main(string[] args)
        {
            //SimpleEmployeeClass();
            bool processing = false;
            do
            {
                processing = processMenu();
            }while(processing);
            
        }

        private static void SimpleEmployeeClass()
        {
            //U cannot use the class directly.
            //U should create the instance of the class to use it.
            Employee e1 = new Employee(); //creating the instance of the class Employee. e1 is the reference variable that holds the reference of the object created in the heap memory.
            e1.EmpID = 101;
            e1.EmpName = "Phaniraj";
            e1.EmpAddress = "Bangalore";
            e1.EmpSalary = 50000;

            Console.WriteLine($"Employee ID: {e1.EmpID}");
            Console.WriteLine($"Employee Name: {e1.EmpName}");
            Console.WriteLine($"Employee Address: {e1.EmpAddress}");
            Console.WriteLine($"Employee Salary: {e1.EmpSalary}");

            Employee e2 = new Employee { EmpID = 123, EmpName = "Joe Biden", EmpAddress = "New York", EmpSalary = 60000 };//Type initialization syntax introduced in .NET 3.5.

            Console.WriteLine($"The name of this Employee is {e2.EmpName} from {e2.EmpAddress} earning a salary of {e2.EmpSalary} and has an iD of {e2.EmpID}");
        }
    }
}

//TODO: Understand this repo pattern and develop a application to store books for a BookStore. It shall have functions to add, delete, update books. 
//SOLID Principles of OOP. Single responsibility, Open Closed, Luskov Substitution, Interface segregation, Dependency inversion principle. 