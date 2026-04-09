using System;

//var is a keyword in C# introduced in .NET 3.5. it is called Implicit typed variables. U can now create local variables without explicitly specifying the type.
//The compiler will infer the type of the variable based on the value assigned to it at compile time.
//This can make code more concise and easier to read, especially when dealing with complex types or anonymous types. However, it is important to note that var can only be used for local variables,
//It cannot be used for fields, properties, or method parameters or method return types. Additionally, once a variable is declared with var, its type cannot be changed later in the code.
//var must be assigned at the line of declaration only.
//It is more a convinience feature for developers, and it does not change the underlying type of the variable. The variable will still have a specific type that is determined at compile time, and it will behave just like any other variable of that type.
//PLAN: Rewrite the whole Calc Program using var instead of explicit typed variables. 
namespace Day2ConsoleApp
{
    internal class Ex04UsingVarKeyword
    {
        static void Main(string[] args)
        {
            //double val2;

            //val2 = 234.566;
            //Console.WriteLine("The value entered is " + val2);
            //var value = 123;
            ////double v1 = 45.67; //explicitly declaring the type of variable v1 as double
            //var v1 = 45.67;//implicitly declaring the type of variable v1 as double using var keyword.
            //Console.WriteLine(v1);
            ////v1 = "Some Text";//compile Error, the variable is already set to be double.
            ///////////////////////CALC PROGRAM///////////////////////
            Console.WriteLine("Enter the First Value");
            var num1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Second Value");
            var num2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Operand as [+, - , *, /]");
            var operand = Console.ReadLine();
            var result = 0.0;
            ////Using if..else conditions for a change. 
            if(operand == "+")
            {
                result = num1 + num2;
            }
            else if(operand == "-")
            {
                result = num1 - num2;
            }else if(operand == "*")
            {
                result = num1 * num2;
            }
            else if( operand == "/") 
            {
                result = num1 /num2;
            }
            else
            {
                Console.WriteLine("Invalid Result");
            }
            Console.WriteLine("The result of this operation is " + result);
        }
    }
}
