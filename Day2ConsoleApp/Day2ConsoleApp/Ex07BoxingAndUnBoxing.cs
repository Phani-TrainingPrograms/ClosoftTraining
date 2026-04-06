using System;

//.NET gives a data type called object, which can be used to store any type of data. 
//This type is the base type for all the data types of .NET. This is part of the CTS (Common Type System) of .NET. The object type can be used to store any type of data, but it is not recommended to use it for storing value types, as it can lead to performance issues due to boxing and unboxing.
//When a value is assigned to an object, it hides its behaviour and stores the value as an object. This process is called boxing. 
namespace Day2ConsoleApp
{
    internal class Ex07BoxingAndUnBoxing
    {

        //If U want to create a function that can return any type of data based on some condition that is evaluated at runtime, then the function's return type could be an object. To retrieve the original behavior of the value stored in the object, U need to perform unboxing, which is an explicit cast that U do for object types to retrieve back their original behavior.
        //UNBOXING can be applied on only to that type from which it was boxed. If the original value was an int, then U can only unbox it to an int. If U try to unbox it to a different type, it will throw an InvalidCastException at runtime.
        static void Main()
        {
            object value = 123; //U R storing an int into an object.
            object value2 = 234.456;
            object value3 = "Text Message";

            object copy = (int)value + 123;//UNBOXING is an explicit cast that U do for object types to retrieve back their original behavior. 

            //TODO: How is this different from var? //object can store any kind of data even after assignment. var does not do that. var does not boxing or unboxing. var is purely a syntactical sugar for the compiler to infer the type of the variable based on the assigned value. Once the type is inferred, it cannot be changed. object can be used as return type of a function, args for a function, fields of a class which cannot be done with var. var is purely a local variable.
            //

            //Equals methods allows you to perform value comparison b/w 2 objects. It is a method created in Object class which can be modified by the programmer to perform value comparison based on the type of the object. 

            object tempObj = 123;
            object tempObj2 = tempObj;//setting the reference of tempObj2 to the same reference of tempObj. 
            Console.WriteLine(tempObj.Equals(tempObj2));
            tempObj = 234;
            Console.WriteLine($"The value of tempObj2 is {tempObj2}");
            Console.WriteLine(tempObj.Equals(tempObj2));
            //Using OOP, we can modify the way Equals method works to suit our requirement of defining the equality of the objects of our class. 
        }


    }
}
