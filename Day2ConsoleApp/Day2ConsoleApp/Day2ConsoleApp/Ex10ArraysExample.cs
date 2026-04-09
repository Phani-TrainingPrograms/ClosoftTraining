using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

//What is an array: Array is a variable that can hold multiple values of the same type. When created as an Array, it is easy to perform some set of common operations on those variable where each value can be identified by an INDEX.  An Array is the simpliest form of data Structure. 
//Arrays are fixed in size. If U want to store more values than the size of the array, then U need to create a new array with a larger size and copy the existing values to the new array. This can be done using the Array.Copy method or by using a loop to copy the values manually. Alternatively, U can use a dynamic data structure like List<T> which can grow in size as needed without having to create a new array and copy the values.

//How to create on objects?
namespace Day2ConsoleApp
{
    internal class Ex10ArraysExample
    {
        static void Main()
        {
            //integerArray();
            //stringArray();
            //MultiDimensionalArray();
            JaggedArrays();
        }

        private static void JaggedArrays()
        {
            //Array of Arrays is called as JAGGED ARRAY. A school has array of classrooms where each room again has array of students. So we can create a jagged array to represent this scenario. In a matrix format, U will have fixed no of rows but variable no of columns in each row. 
            int[][] school = new int[3][];//This will create an array of 3 classrooms, but the number of students in each classroom is not defined yet.
            school[0] = new int[] { 234,45,657 };//This will create an array of 2 students in the first classroom.
            school[1] = new int[] { 234,45,657, 234,45,657 };//This will create an array of 4 students in the second classroom.
            school[2] = new int[] { 234,45,657, 234,45,657, 234,45,657 };//This will create an array of 6 students in the third classroom.

            //display the values in the jagged array.
            for(int i = 0; i < school.Length; i++)
            {
                foreach(var student in school[i])
                {
                    Console.Write(student + "\t");
                }
                Console.WriteLine();//move to the next line.
            }
        }

        private static void MultiDimensionalArray()
        {
            int[,] matrix = new int[3, 4];//Syntax of creating 3x4 array.
            //nested loop to set values in the multi-dimensional array.                              
            Console.WriteLine("The no of dimensions for this array is " + matrix.Rank);
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.WriteLine($"Enter the value for index [{i},{j}]");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            //Display the values in a matrix format.
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();//move to the next line.
            }
            //Multi dimensional arrays are very impractical. They are not used in real world applications. They are only used for academic purposes to understand the concept of arrays. In real world applications, we use jagged arrays or List of Lists to achieve the same functionality as multi-dimensional arrays. Classes and objects are prefered over multi-dimensional arrays to achieve the same functionality.
        }



        private static void stringArray()
        {
            //Every Array is an object of a class called System.Array. This class provides some properties and methods to perform some common operations on the array.
            string[] names = new string[5];

            for(int i = 0; i < names.Length; i++)//Length is a property to get the size of the array
            {
                Console.WriteLine("Enter the Name");
                names[i] = Console.ReadLine();
            }
            //foreach is forward only and Readonly. I cannot use foreach for setting values in the array. I can only use it for reading the values of the array. 
            foreach(var name in names)
                Console.WriteLine(name);
        }

        private static void integerArray()
        {
            //Data-Type [] variableName = new Data-Type[size];//size should be a whole number. 
            int[] numbers = new int[5];//This will create an array of integers with a size of 5. The array will be initialized with default values of 0 for each element.
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter the value for index {i}");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("All the values are set, lets iterate to read them");
            foreach(var item in numbers)
            {
                Console.WriteLine(item);
            }
            //foreach is a loop that can be used to iterate thru the elements of an array or a collection. It is simple and will not go out of bounds of the array. U dont need to check the size or the index of the array while using foreach loop. 
        }
    }
}
