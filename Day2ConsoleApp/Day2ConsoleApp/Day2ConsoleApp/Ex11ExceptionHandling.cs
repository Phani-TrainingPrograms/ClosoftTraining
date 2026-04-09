using System;
using System.IO;
using System.Runtime.Remoting.Messaging;
//Excpetion handling is a mechanism to handle Runtime errors in a graceful manner. 
//It allows to write code that can handle any unforseen abnormalities that could occur during the Execution of the Program. 
//This could a file that U want to access might not be available, user might enter invalid values, DB connection could have failed due to wrong entries and many more. If U dont handle these exceptions, there is a possibility that the program might crash. Instead we handle it and gracefull display the error message to allow the user to make corrections and try again.
//Any Exception raised by the System will be an object of a class called Exception and its derived classes. For invalid inputs, Exception is InvalidFormatException
//Every Exception handling code in C# will have a try block and one ore more catch blocks. Each catch block will handle a specific type of exception. The catch block that matches the type of exception raised will be executed. If there is no catch block that matches the type of exception raised, then the program will crash or it shall pass the Exception to the caller. If the caller of the function also does not handle the exception it shall reach the top level till either the exception handling is done or it reaches the Main block. Even if the exception is not handled in the Main block, it will be handled by the runtime and it will display a message to the user and then terminate the program. This is Exception Funnelling.
//There is an optional block called finally block which will be executed regardless of whether an exception is raised or not. This block is used to release any resources that were acquired in the try block. For example, if U open a file in the try block, U can close the file in the finally block to ensure that the file is closed even if an exception is raised. This is applicable for Database connections also. 

//U can create Custom Exceptions by creating a class that inherits from the Exception class. This allows U to create exceptions that are specific to your application and provide more meaningful error messages to the user.
//For example, if U have an application that processes orders, U can create a custom exception called OrderProcessingException that inherits from the Exception class. This exception can be thrown when there is an error processing an order and can include additional information about the order that caused the error. Application specific exceptions can help to make the code more readable and maintainable by providing more context about the error that occurred.
//Exception handling is more like a last resort to fix an issue. It should not be a primary way to control the flow of the Program. 
//Anticipate the errors and try to fix it using code and use catch block as a final resort for those unforseen errors. 
namespace Day2ConsoleApp
{
    class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(string message) : base(message) //This will call the base class version to make the nessasary arrangements for setting the Error message and other properties of the Exception class. 

        {

        }

        public EmployeeNotFoundException() //Here I dont need to use the Base keyword as I am not passing any message to the base class constructor and is implicit.
        {
            
        }
    }
    internal class Ex11ExceptionHandling
    {
        static void Main(string[] args)
        {
            //basicExceptionHandling();
            //usingCustomExceptions();
            //try
            //{
            //    string contents = File.ReadAllText("Sample.txt");
            //    Console.WriteLine(contents);
            //}
            //catch(FileNotFoundException)
            //{
            //    Console.WriteLine("Sorry, file is not available");
            //}

            //if(!File.Exists("Sample.txt"))
            //{
            //    Console.WriteLine("Sorry, file is not available to read");
            //    return;
            //}
            //var contents = File.ReadAllText("Sample.txt");
            //Console.WriteLine(contents);
            //Todo: TryParse in C#, Find out what it does. 

        }

        private static void usingCustomExceptions()
        {
            try
            {
                Console.WriteLine("Enter the Id to search");
                int id = int.Parse(Console.ReadLine());
                if(id < 5 & id > 0)
                {
                    Console.WriteLine("Employee found with Id " + id);
                }
                else
                {
                    throw new EmployeeNotFoundException($"Employee with Id {id} not found.");//This will create an instance of the EmployeeNotFoundException class and throw it to the caller. The message passed to the constructor will be set as the Message property of the Exception class.
                }
            }
            catch(EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid Number");
            }
            catch(OverflowException)
            {
                Console.WriteLine("The number is too large or too small for an integer.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        private static void basicExceptionHandling()
        {
        TRYAGAIN:
            Console.WriteLine("Enter a number");
            try
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("The value available is " + number);
            }
            catch(FormatException)
            {
                Console.WriteLine("Please enter a valid number");
                goto TRYAGAIN;//This will jump to the label TRYAGAIN and execute the code from there. This is not a good practice to use goto statement in C#. It can make the code difficult to read and maintain. It can also lead to infinite loops if not used carefully. It is better to use a loop or a method to achieve the same functionality. For handling repeated attempts, we can use GOTO Statements.
            }
            catch(OverflowException)
            {
                Console.WriteLine($"The value is too big for an integer number. Please set {int.MinValue} to {int.MaxValue}");
                goto TRYAGAIN;
            }
            catch(Exception ex)//For any other Exceptions. Note that General Exception shall be the last catch block as it will catch all the exceptions and the specific exceptions will never be reached.
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                goto TRYAGAIN;
            }
            finally
            {
                Console.WriteLine("This is more like clean up block that executes on all conditions, whether an exception is raised or not.");

            }
        }
    }
}
