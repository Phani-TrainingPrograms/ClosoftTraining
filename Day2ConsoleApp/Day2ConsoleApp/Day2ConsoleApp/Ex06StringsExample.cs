using System;
using System.Text;//String manupulations.

//strings are immutable. Whenever U modify a string, a new string is created in memory and the original string remains unchanged. This is because strings are reference types in C#, and they are stored in the heap memory. When you modify a string, a new string object is created in the heap memory, and the reference to the original string is updated to point to the new string object.
//This immutability of strings can lead to performance issues if you need to modify a string frequently, as it can result in a lot of memory allocation and garbage collection. To avoid this issue, you can use the StringBuilder class, which provides a mutable string-like object that can be modified without creating new objects in memory.

namespace Day2ConsoleApp
{
    internal class Ex06StringsExample
    {
        static void Main()
        {
            string strText = "Hello World";
            Console.WriteLine(strText.ToUpper());
            Console.WriteLine(strText.ToLower());
            string subText = strText.Substring(0, 5);//this will extract the substring "Hello" from the original string "Hello World". The first parameter is the starting index (0-based) and the second parameter is the length of the substring to be extracted.
            Console.WriteLine(subText);
            //A string is an array of characters. So we can access each character of the string using its index.
            Console.WriteLine($"The First char of this string {strText} is {strText[0]}");
            for(int i = 0; i < strText.Length; i++)
            {
                Console.WriteLine(strText[i]);
            }
            //I want to split the words within the string.
            var words = strText.Split(' ');//Splits the string into an array of strings. 
            for(int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }
            //Reading a CSV File needs to split each line based on ,. 

            //string builder class is recommended for string manipulation when you need to modify a string frequently, as it provides a mutable string-like object that can be modified without creating new objects in memory. It is more efficient than using string concatenation or other string manipulation methods that create new string objects in memory.
            var builder = new System.Text.StringBuilder();
            builder.Append("Hello");//this will add the string "Hello" to the StringBuilder object.
            builder.Append(" World");//this will add the string " World" to the StringBuilder object.
            Console.WriteLine(builder.ToString());
        }
    }
}
