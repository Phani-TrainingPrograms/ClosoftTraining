using System;

//variable type conversions are the process of converting a value from one data type to another.
//In C#, there are two types of type conversions: implicit and explicit.
//Lower range variables can be implicitly set to higher range variables, but the reverse needs explicit conversion. This explicit conversions are called TYPE CASTING. Type casting is the process of converting a value from one data type to another by explicitly specifying the target type.
//This can be done using the cast operator (()) or using the Convert class.
//Ctrl+K+F is used to format the code in Visual Studio. It helps to improve the readability of the code by properly indenting and aligning the code elements.


namespace Day2ConsoleApp
{
    internal class Ex05TypeConversions
    {
        static void Main(string[] args)
        {
            int iValue = 123; //shorter range variable
            long dValue = iValue;//long is a higher range variable than int, so this conversion is implicit and does not require any special syntax.

            //try the reverse of this:
            int iVal2 = (int)dValue;//compile error, C# follows C Style casting..
            Console.WriteLine(iVal2);

            //What is the range of each data type?
            Console.WriteLine("The Range of byte is " + byte.MinValue + " to " + byte.MaxValue);
            Console.WriteLine($"The Range of Short is {short.MinValue} to {short.MaxValue}");//Interpolation syntax for string formatting, it is more readable and easier to use than concatenation.
            Console.WriteLine($"The Range of integer is {int.MinValue} to {int.MaxValue}");
            Console.WriteLine($"The Range of long is {long.MinValue} to {long.MaxValue}");
            Console.WriteLine("The Range of Unsigned Long is {0} to {1}.The lowest value for unsigned is always 0", ulong.MinValue, ulong.MaxValue);//VS 2008 or something, VS2010 we have .NET 4.0, we can use interpolation syntax for string formatting, but in older versions of C#, we have to use the format specifier syntax for string formatting, which is less readable and more error-prone than interpolation syntax.

            //TODO: Display the range of all the data types of C# language. 

            /////////////////CONVERT CLASS//////////////////////
            int iVal3 = Convert.ToInt32(123.45);//this will convert the double value 123.45 to an integer value 123 by truncating the decimal part.
            Console.WriteLine($"The value of iVal3 is {iVal3}");
            double dValue2 = Convert.ToDouble("123.456");//From which type to which type are we converting? string to double.
            long lValue2 = Convert.ToInt64(123.45);//this will convert the double value 123.45 to a long value 123 by truncating the decimal part.
            Console.WriteLine($"The Long value is {lValue2}" );
            /////////////////////Why not CASTING?//////////////////////
            long lValue3 = int.MaxValue;
            int iVal = (int)(lValue3 + 123);//NOT SAFE, this will cause an overflow because the result of lValue3 + 123 exceeds the maximum value of int. The cast operator will not check for overflow and will simply truncate the result to fit into an int, which can lead to unexpected results.
            //So it is always better to use the Convert class for type conversions, as it provides methods that can handle overflow and other conversion errors gracefully, by throwing exceptions that can be caught and handled in the code.
            Console.WriteLine($"The Value of iVal is {iVal}");

            iVal = Convert.ToInt32(lValue3 + 123);//throws an OverflowException instead of unexpected results.
        }
    }
}
