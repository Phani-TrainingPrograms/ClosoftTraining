using System;

//variables are identifiers given to store inputs from the application for a later use. Variables are used to store data in memory and can be of different data types such as int, string, float, etc. In C#, we need to declare a variable before using it. The syntax for declaring a variable is as follows:
//data_type variable_name;
//variable is determined by the following rules:
//What kind of data U want to store in the variable(DataType).
//How big is UR Variable(Size).
//How long you need to store this variable(Lifetime).
//How do you want to use this variable(Scope).

//Do paper work. path of execution. 
//Calc Program:
//1. Take input from the user for two numbers(Numerical) and an operator(string).
//2. Perform the calculation based on the operator(Decision making) and print the result to the console.
//Variables in C# are based on CTS(Common Type System).
//CTS defines a set of data types that are supported by the .NET framework.
//These data types are categorized into two main categories: value types and reference types.
//Value types include simple and primitive data types such as int, float, bool, etc.
//Reference types include complex data types such as classes, interfaces, arrays, etc.
//When we declare a variable of a value type, it directly holds the value in memory.
//In value types we have 4 divisions:
//1. Integral types: These include byte(8 Bit), Short(16), Int(32) and long(64) . They are used to store whole numbers of different sizes and ranges.
//2. Floating-point types: These include float(32) , double(64) and decimal(128). They are used to store decimal numbers with different precision. 
//3. Other value types: These include bool, char. They are used to store other types of data such as true/false values and single characters.
//4. User Defined Types: structs and enums. They are used to create custom data types that can hold multiple values of different types.

//Every value type has Parse Method to convert a string to its type. 
//How can we resolve multiple Main methods in a single project?
namespace Day2ConsoleApp
{
    class Ex02VariablesDemo
    {
        static void Main()
        {
            Console.WriteLine("Enter your age");
            int age = int.Parse(Console.ReadLine());//parse is a method of the int struct that converts string to a integer. It throws an Exception if the input is not a valid integer.
            Console.WriteLine("My age is " + age);
            Console.WriteLine("U R planning to retire by " + (60 - age) + "years");

            Console.WriteLine("Enter the Mobile no");
            long mobileNo = long.Parse(Console.ReadLine());
            Console.WriteLine("My mobile number is " + mobileNo);

            Console.WriteLine("Enter the Salary of the employee");
            double salary = double.Parse(Console.ReadLine());
            Console.WriteLine("The salary of the employee is " + salary);
        }
    }
}
