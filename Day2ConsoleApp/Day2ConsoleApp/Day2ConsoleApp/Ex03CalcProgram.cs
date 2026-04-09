using System;


namespace Day2ConsoleApp
{
    internal class Ex03CalcProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the First Value: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Second Value: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Operand (+, -, *, /): ");
            string operand = Console.ReadLine();

            double result = 0.0;
            //decision making statement.
            switch(operand)
            {
                case "+":
                    result = num1 + num2;
                    break;//exits the switch statement and continues with the next statement after the switch block.
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                default:
                    Console.WriteLine("Invalid Choice from the user");
                    return;//exit the function
            }
            Console.WriteLine("The result of the operation is " + result);
        }
    }
}
