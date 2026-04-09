//Class is the fundamental Unit of any C# Application. Namespace is optional. It is used to logically group the related classes. It also helps to avoid name conflicts.
//The Main method is the entry point of any C# Application. It is the first method that gets executed when the application starts. It is a static method and it must be declared inside a class. The Main method can have two signatures:
//1. static void Main() - This is the most common signature of the Main method. It does not take any parameters and does not return any value.
//2. static void Main(string[] args) - This signature of the Main method takes an array of strings as a parameter. This array contains the command-line arguments passed to the application when it is executed. The Main method can also return an integer value, which is used as the exit code of the application. The default exit code is 0, which indicates that the application executed successfully. If the Main method returns a non-zero value, it indicates that an error occurred during the execution of the application.

//statements in C# has to be a part of a function. U cannot write statements directly inside a class. 
//Write vs. WriteLine :
//Console.Write() is used to write the output to the console without adding a new line at the end.
//Console.WriteLine() is used to write the output to the console and adds a new line at the end.


//Console.ReadLine(): To take input from the user, we can use the Console.ReadLine() method. This method reads a line of input from the console and returns it as a string. We can store this input in a variable and use it later in our program.

//Any input into the system in any programming language is treated as a string. If we want to convert this input into a different data type, we can use the appropriate conversion method.
//Likewise, any output that U send out of the system shall be again string only. 
using System; // This is a using directive. It allows us to use the classes and methods defined in the System namespace without having to fully qualify their names. For example, we can use Console.WriteLine instead of System.Console.WriteLine.
class Day2Session
{
    static void Main()
    {
        //inside this block, UR statements and expressions are written. 
        Console.Write("Hello World! ");
        Console.WriteLine("Pleae tell me UR Name only");
        string answer = Console.ReadLine();

        Console.WriteLine("Enter your city");
        string city = Console.ReadLine();
        Console.WriteLine("U have entered UR Name as " + answer + " UR City is " + city);

        //todo:
        //Ask the user about his age, his city and his mobile number and print all the details back to the user in a single line.
    }
}
//To execute this program, U should Ctrl + F5 or click on the Start button in Visual Studio. This will build and run the application, and you should see "Hello World" printed in the console window. F5 is used to debug the Application.