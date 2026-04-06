using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//if..else
//switch case
//do..while
//for loop
//foreach loop
namespace Day2ConsoleApp
{
    internal class Ex09StatementsAndExpressions
    {
        //if else is a conditional statement that allows you to execute a block of code based on a condition. The if statement is used to test a condition, and if the condition is true, the block of code within the if statement is executed. If the condition is false, the block of code within the else statement is executed. The else if statement can be used to test multiple conditions, and it allows you to execute different blocks of code based on different conditions.
        static void ifElseExample()
        {
            Console.WriteLine("Enter a number:");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num > 0)
            {
                Console.WriteLine("The number is positive.");
            }
            else if (num < 0)//optional blocks
            {
                Console.WriteLine("The number is negative.");
            }
            else//optional block
            {
                Console.WriteLine("The number is zero.");
            }
        }

        //If U have large variations of conditions to check, then we use switch case, a better approach than if else. Switch case is a control statement that allows you to execute a block of code based on the value of a variable. The switch statement evaluates the value of the variable and compares it to the values specified in the case statements. If a match is found, the block of code associated with that case is executed. If no match is found, the block of code associated with the default case is executed (if it exists). Switch case is often used when there are multiple conditions to check, as it can make the code more readable and easier to maintain compared to using multiple if else statements.
        static void switchCaseExample()
        {
            Console.WriteLine("Enter the Profile as [Trainer, Developer, Manager]:");
            string profile = Console.ReadLine().ToUpper();
            switch(profile)
            {
                case "TRAINER":
                    Console.WriteLine("You are a Trainer.");
                    break;
                case "DEVELOPER":
                    Console.WriteLine("You are a Developer.");
                    break;
                case "MANAGER":
                    Console.WriteLine("You are a Manager.");
                    break;
                default:
                    Console.WriteLine("Invalid Profile.");
                    break;
            }
        }

        static void Main(string[] args)
        {
            //ifElseExample();
            //switchCaseExample();
            //doWhileExample();
            forLoopExample();

        }

        private static void forLoopExample()
        {
            //Execute a block of code for a specific number of times. It consists of three parts: the initialization, the condition, and the increment/decrement. The initialization is executed only once at the beginning of the loop, and it is used to initialize the loop variable. The condition is evaluated before each iteration of the loop, and if it evaluates to true, the block of code within the loop is executed. The increment/decrement is executed after each iteration of the loop, and it is used to update the loop variable. For loop is often used when you know in advance how many times you want to execute a block of code.

            for(int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Enter UR Name");
                string name = Console.ReadLine();
                Console.WriteLine($"The Name entered is {name} for the index {i}");
            }

            //U can use for loop to iterate in reverse order as well.
            for(int i = 2; i >= 0; i--) //-- decrements by 1.  
            {
                Console.WriteLine("Enter UR Name");
                string name = Console.ReadLine();
                Console.WriteLine($"The Name entered is {name} for the index {i}");
            }//TODO: test this code and see the output.
        }

        //if U want to execute a block of code multiple times based on a conditions, then we can go for LOOPS. The do...while loop is the most prefered way of looping the code. This ensures that the code block executes atleast once and then evaluates a condition that determines whether the loop should redo the code block or not. This will help in a menu driven program where the menu shall be displayed at least once. 
        static void doWhileExample()
        {
            int choice = 0;
            do
            {
                choice = ProcessMenu();
            } while(choice < 6 && choice > 0);
            //todo: Implement the logic for each choice in the menu as seperate Functions and call them here. 

        }

        static int ProcessMenu()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~MATH CALCULATOR~~~~~~~~~~~~~~~");
            Console.WriteLine("Press 1 to Add numbers");
            Console.WriteLine("Press 2 to Subtract numbers");
            Console.WriteLine("Press 3 to Multiply numbers");
            Console.WriteLine("Press 4 to Divide numbers");
            Console.WriteLine("Press 5 to Find SquareRoot of a number");
            Console.WriteLine("PS: Any other value is considered as exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
    }
}
