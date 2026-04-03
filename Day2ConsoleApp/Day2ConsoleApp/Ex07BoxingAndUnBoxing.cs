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

            object copy = (long)value + 123;//UNBOXING is an explicit cast that U do for object types to retrieve back their original behavior. 

            //TODO: How is this different from var? 
        }
    }
}
