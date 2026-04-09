using Microsoft.Win32;
using System;
using System.Collections.Generic;
//When we work with multiple objects grouped into single Unit, we call that unit as collection. With Collection, U have ability to iterate all the members of the collection using a simple foreach loop, U can add, remove elements depending on the type of collection that U want to create and use. 
//In C#, we have Generics namespace that contains pre built classes that U can use to store data in memory.
//List<T> is a Generic collection class  that stores data and allows to add, remove at any point within it. 
//Arrays are fixed in size. With it, it is not possible to expand the array in a easy manner. We dont have built in methods like add, remove, insert to manupulate the array at runtime. 
//To Solve this problem, we use Collection Classes like List, Queue, Stack etc.
//All the Generic Collections are defined under the namespace System.Collections.Generic. 
//Further to explore, U create Custom Collection classes.... 
namespace AdvancedProgramming
{
    internal class Ex14GenericCollections
    {
        static void Main(string[] args)
        {
            QueueExample();
            StackExample();
            DictionaryExample();
            HashSetExample();
            listExample();
        }

        private static void QueueExample()
        {
            Queue<string> recentlyViewed = new Queue<string>();
            recentlyViewed.Enqueue("Apples");
            recentlyViewed.Enqueue("Mangoes");
            recentlyViewed.Enqueue("Oranges");
            recentlyViewed.Enqueue("PineApples");
            recentlyViewed.Enqueue("IPhone");
            foreach(var item in recentlyViewed)
                Console.WriteLine(item);
            if(recentlyViewed.Count == 5)
            {
                recentlyViewed.Dequeue(); //Removes the first item in that list. 
            }
            recentlyViewed.Enqueue("Samsung Phone");
            foreach(var item in recentlyViewed)
                Console.WriteLine(item);
        }

        private static void StackExample()
        {
            Stack<string> books = new Stack<string>();
            books.Push("Book1");
            books.Push("Book2");
            books.Push("Book3");
            books.Push("Book4");
            //To remove a stack, U should be able to remove the top one only. 
            books.Pop();//last book that was added shall be removed. 
            foreach(var book in books)
                Console.WriteLine(book);
        }

        private static void DictionaryExample()
        {
            //Dictionary is a collection class that stores 2 sets of values within it. They are called as KEY-VALUE Pairs. Key is unique to the collection, value for that key may not be unique. 
            Dictionary<string, string> users = new Dictionary<string, string>();
            users.Add("Phaniraj", "test123");
            //users.Add("Phaniraj", "test123");
        TRYAGAIN:
            Console.WriteLine("Enter the User name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter the Password");
            var pwd = Console.ReadLine();
            if(users.ContainsKey(name))
            {
                Console.WriteLine("User name is already taken");
                goto TRYAGAIN;
            }
            //if users has to throw an exception if a key already exists, then use add method. 
            users.Add(name, pwd);
            //users[name] = pwd;//Here in this case, if name already exists, pwd is set to again so replacing the pwd. else new key and value pair is created and added to the users dictionary.

        }

        //HashSet is similar to List, except that it stores only unique data. 
        private static void HashSetExample()
        {
            HashSet<string> list = new HashSet<string>();
            list.Add("Apples");//Add method unlike List's Add method returns a bool that tells if the insertion was successfull or not. true means success. failed could be the uniqueness was not met. 
            list.Add("Apples");
            list.Add("Apples");
            Console.WriteLine("The Count of fruits is " + list.Count);

            List<object> objects = new List<object>();
            objects.Add(new { Item1 = "Apples", Item2 = "Mangoes" });
            foreach(var item in objects)
                Console.WriteLine(item);

            //Internally, Hashset uses HashCode to determine the uniqueness of the data U try to insert. 

            HashSet<Employee> uniqueList = new HashSet<Employee>();
            var emp = new Employee { EmpID = 123, EmpName = "Phaniraj", EmpAddress = "Bangalore", EmpSalary = 45000 };
            var emp2 = new Employee { EmpID = 123, EmpName = "Phaniraj", EmpAddress = "Bangalore", EmpSalary = 45000 };
            uniqueList.Add(emp);
            uniqueList.Add(emp2);
            Console.WriteLine("The Count of employeesd is " + uniqueList.Count);

            //an object uniquness is recognized by its HashCode and Equals method. 
        }

        private static void listExample()
        {
            List<string> fruits = new List<string>();
            fruits.Add("Apples");
            fruits.Add("Mangoes");
            fruits.Add("Oranges");
            fruits.AddRange(new string[] { "PineApples", "KiwiFruits", "Gauvas" });
            Console.WriteLine("The Total no of fruits with us is: " + fruits.Count);
            //Count is a property of List<T> class that gives the total no of elemens within the collection.
            foreach(var item in fruits)
            {
                Console.WriteLine(item);
            }
            var success = fruits.Remove("Gauva");//returns true if the item is removed successfully. 
            if(!success)
                Console.WriteLine("Fruit was not able to be removed");
            Console.WriteLine("The Total no of fruits with us is: " + fruits.Count);
            for(int i = 0; i < fruits.Count; i++)
            {
                if(fruits[i] == "Gauvas")
                    fruits.RemoveAt(i);
            }
            Console.WriteLine("The Total no of fruits with us is: " + fruits.Count);
            //List has capability to work on custom classes and objects and is widely used in Applications. 
            //List cannot ensure that U have unique values in it. 
        }
    }
}
