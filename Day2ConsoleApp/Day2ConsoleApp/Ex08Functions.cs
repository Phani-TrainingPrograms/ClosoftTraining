using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Fundamentals of a function in C#...
//Function is a block of code that performs a specific task. It contains multiple statements that are executed when the function is called.
//A Programmer shall create a function only if there is block of code that is repeatedly used across the program. If there is a block of code that is used only once, then it is not recommended to create a function for it, as it can lead to unnecessary overhead and complexity in the code. It is better to keep the code simple and straightforward in such cases.
//Programmers follow a pattern called KISS: KEEP IT SIMPLE STUPID. This pattern suggests that programmers should keep their code simple and straightforward, and avoid unnecessary complexity. This can help to improve the readability and maintainability of the code, and make it easier for other developers to understand and work with the code in the future.
//Callng a function implies that U refer/invoke this function directly or indectly from MAIN function. When a function is called, the program execution jumps to the function's code block, executes the statements within the function, and then returns back to the point where the function was called. This allows for code reuse and modular programming, as functions can be defined once and called multiple times throughout the program. 
//Too many things are done in that function. Taking inputs, computing it and finally displaying the output. This is not a good practice.
//Function should do only one thing. 

namespace Day2ConsoleApp
{
    internal class Ex08Functions
    {
        //Create a function to add numbers.
        public static void AddNumbers()
        {
            Console.WriteLine("Enter the First Value");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the Second Value");
            double num2 = Convert.ToDouble(Console.ReadLine());
            double sum = num1 + num2;
            Console.WriteLine($"The Added value is {sum}");
        }

        //Add function should only add when 2 numbers are given to it. It should not take input from the user or display the output. It should only take 2 numbers as input(parameters) and return the sum of those 2 numbers. This is a good practice to follow, as it makes the function more reusable and easier to test.
        //Parameters of a function are variables that are injected into the function and this function uses those parameters to perform a task. This is dependency injection.
        //Any opeations that U perform in a function are limited within that function. If U want the result to be accesible from the calling section, then U must return that value. Functions need return type for this reason. 
        public static double AddNumbers(double num1, double num2)
        {
            double sum = num1 + num2;
            return sum;
        }

        //C# Newer version that allows to create functions that return more than one value. This is called tuple. A tuple is a data structure that can hold multiple values of different types. It is a convenient way to return multiple values from a function without having to create a separate class or struct to hold those values. In C#, you can use the ValueTuple type to create tuples, which allows you to return multiple values from a function in a single return statement.

        static (double, double, double) ComputeValues(double v1, double v2)
        {
            double sum = v1 + v2;
            double product = v1 * v2;
            double difference = v1 - v2;
            return (sum, product, difference);
        }

        static void MultipleNumbers()
        {
            Console.WriteLine("Enter the First Value");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the Second Value");
            double num2 = Convert.ToDouble(Console.ReadLine());
            double product = num1 * num2;
            Console.WriteLine($"The Product value of {num1} and {num2} is {product}");
        }

        static void Main(string[] args)
        {
            AddNumbers();
            MultipleNumbers();
            var results = ComputeValues(10, 5);
            Console.WriteLine($"The added value is {results.Item1}");
            Console.WriteLine($"The product value is {results.Item2}");
            Console.WriteLine($"The difference value is {results.Item3}");
        }
    }
}
