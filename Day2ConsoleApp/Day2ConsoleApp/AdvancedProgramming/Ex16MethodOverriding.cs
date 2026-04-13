using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//If a base class has a function, and UR derived class wants to modify that function, then this feature is called method overriding. This feature shall support RUNTIME POLYMORPHISM. 
//in this case, the base class shall provide the permission to allow the derived class to modify them. It is given using virtual keyword on the function declaration.
//Derived class shall take that permission and modify it using override. Only virtual functions can be overriden. 
//If U dont mark the function as virtual, U cannot use override on those functions in the derived class.
//however, U can skip using override on the derived class function and due to which Runtime Polymorphism shall not work. 
//When U override a method, the signature of the function must not be altered. its parameters shall not change. 
namespace AdvancedProgramming
{
    class FatherClass
    {
        //virtual makes the function modifiable in the derived class. 
        public virtual void MakePayment(string paymentMode, int amount)
        {
            if(paymentMode.ToLower() == "cash" || paymentMode.ToLower() == "cheque")
                Console.WriteLine($"The Payment of Rs. {amount} is recieved via {paymentMode}");
            else
                Console.WriteLine("Invalid mode of payment");
        }
    }

    class SonClass : FatherClass
    {
        public override void MakePayment(string paymentMode, int amount)
        {
            if(paymentMode.ToLower() == "cash" || paymentMode.ToLower() == "cc" || paymentMode.ToLower() == "upi")
                Console.WriteLine($"The Payment of Rs. {amount} is recieved via {paymentMode}");
            else
                Console.WriteLine("Invalid mode of payment");
        }
    }
    internal class Ex16MethodOverriding
    {
        static void Main(string[] args)
        {
            FatherClass cls = new FatherClass();
            cls.MakePayment("Cheque", 6000);
            //Same object with same function behaving diffently based on the condition based on the object to which its instantiated is called as RUNTIME POLYMORPHISM.
            cls = new SonClass();//Old customer is talking to Son....
            cls.MakePayment("CC", 6000);
        }
    }
}
