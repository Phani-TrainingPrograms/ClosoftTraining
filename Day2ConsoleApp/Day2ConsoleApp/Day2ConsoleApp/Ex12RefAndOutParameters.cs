using System;

namespace Day2ConsoleApp
{
    //Parameters in C# are passed by value. A copy of the variable shall be created and passed into the function. 
    //Any changes you make to the parameters in the function shall remain only within the function.
    //If U want to retain the changes made to the parameters within the function, U should use either ref or out parameters. 
    //Ref parameters are used when U want to pass a variable by reference and retain the changes made to it within the function. 

    //Pass by out parameter is a sp scenario of ref parameter where the value is not initialized before passing it into the function.
    //U can only assign a value to an out parameter within the function and U cannot read the value of an out parameter before assigning it a value. The function will assign the value here. 
    //This is useful when U want to return multiple values from a function or when U want to return a value from a function without using the return statement.
    internal class Ex12RefAndOutParameters
    {
        static void TestFunc(int num)
        {
            num = num + 10;
            Console.WriteLine($"The value of num in the function is {num}");
        }

        static void ArithematicOperations(int num1, int num2, out int sum, out int product, out int subtractValue, out int divValue)
        {
            sum = num1 + num2;
            product = num1 * num2;
            subtractValue = num1 - num2;
            if(num2 != 0)
                divValue = num1 / num2;
            else
                divValue = 0;
        }
        static void TestFuncPassedByRef(ref int num)
        {
            //Value for the reference should be initialized before U pass it into the function. 
            //U will get compile Error if U dont initialize the variable. 

            num = num + 10;
            Console.WriteLine($"The value of num in the function is {num}");
        }
        static void Main(string[] args)
        {
            int num = 123;
            Console.WriteLine($"The value of num before the Call is {num}");
            //In C#, local variables have to be initialized before U can use them.
            //If U try to use an uninitialized variable, U will get a compile-time error.
            //This is because C# is a statically-typed language, which means that the type of a variable must be known at compile time.
            //When U declare a variable, U need to assign it a value before U can use it in any expression or statement.
            //This helps to prevent abnormal Results and ensures that the program behaves properly.
            TestFunc(num);
            TestFuncPassedByRef(ref num);//num must be initialized before U pass it into the function.
            Console.WriteLine($"The value of num after the Call is {num}");

            /////////////Using Out Parameters Example//////////////
            int sum, product, subtractValue, divValue; //None of them are initialized here.
            ArithematicOperations(10, 0, out sum, out product, out subtractValue, out divValue);
            Console.WriteLine($"The added value is {sum}\nThe Subtracted value is {subtractValue}\nThe Multplied value is {product}\nThe divided value is {divValue}");
            //Practical example of using out parameter inside a function. 
            UsingTryParseFunc();
        }

        static void UsingTryParseFunc()
        {
            //try
            //{
            //    Console.WriteLine("Enter the Number");
            //    int value = int.Parse(Console.ReadLine());
            //    Console.WriteLine($"The value is : {value}");
            //}
            //catch(Exception)
            //{
            //    Console.WriteLine("Invalid number to take as input");
            //}
            //////////Use this instead////////////
            int value;
            Console.WriteLine("Enter the Number");
            if(int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine($"The value is : {value}");
            }
            else
            {
                Console.WriteLine("Invalid number to take as input");
            }
            //TryParse method attempts to parse a string to the specific value type, if fails returns False, else returns true. The parsed value shall be the out parameter of the function so U can use it later. 
        }
    }
}
