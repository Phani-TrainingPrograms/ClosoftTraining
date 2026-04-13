using System;
namespace AdvancedProgramming
{
    //Inheritance is a feature of OOP that allows code reusability.
    //It is based on the concept of Open-Closed Principle.    
    //A class is closed for modification, but is open for Extensions. 
    //A class is immuatable, once the class is created and deployed, it shall not change. 
    //If any changes are expected, it shall be extended and modified, not on the same class.
    //This promotes Reusability and polymorphism (Another feature of OOP).
    internal class Ex13Inheritance
    {
        
        static void Main(string[] args)
        {
            ////////////Showing the demo on derived classes///////////////////////////////////////////
            Customer cst = new Customer();
            cst.setDetails("Phaniraj", "Bangalore");

            //Derived class instance has access to even the base class functions as well as its own functions. 
            ChildCustomer cst2 = new ChildCustomer();
            cst2.setDetails("BaseName", "BaseAddress");//from the base class
            cst2.DisplayDetails();//from the existing class(Dirived class).
        }
    }

    class Customer//Parent class, Base Class, Super Class
    {
        protected string name, address;//data to store, protected makes the members available to its class and its derived classes. 
        public void setDetails(string name, string address)
        {
            this.name = name; //this operator refers to the instance of the class. 
            this.address = address; //this shall allow to refer your fields when there is a naming conflict. 
        }
    }//closed for any modifications. 

    //Syntax for inheritance in C#. All the public members shall be the part of the child class. Private members will not be the part of the child class.
    class ChildCustomer : Customer //ChildClass, Derived Class, Sub Class. 
    {
        public void DisplayDetails()
        {
            Console.WriteLine($"The name is {name} and address is {address}");
        }
    }

}
