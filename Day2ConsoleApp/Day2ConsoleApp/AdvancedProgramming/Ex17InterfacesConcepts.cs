using System;

//Interface is similar to class but has methods in them that are not implemented. They are super versions of Abstract classes.  
//Interfaces do not contain implementaions. The class that derives from the interface must implement those methods and use them. 
//Interface is more like contract, where the contract tells what U will provide. how U provide it is dependent on the implementor class.
//Interface concept is the most popular way of implementing frameworks, reusability and polymorphic behavior at Application level. 
namespace AdvancedProgramming
{
    interface IParty
    {
        void InviteFrieds(string[] friends);
        void PrepareFood();
        void GetCake();

    }

    class MyPersonalParty : IParty
    {
        public void GetCake()
        {
            Console.WriteLine("Prepare the home made cake with Eggless");
        }

        public void InviteFrieds(string[] friends)
        {
            foreach(var friend in friends)
            {
                Console.WriteLine($"Calling {friend} and telling him to come to party in a hotel");
            }
        }

        public void PrepareFood()
        {
            Console.WriteLine("Ordering food in the location where the party is on");
        }
    }
    //If UR class implements an interface, it must implement all the methods of that interface. U cannot miss even one. U cannot change the signature of those methods. The methods must be public only. 
    class BdayParty : IParty
    {
        public void GetCake()
        {
            Console.WriteLine("Getting cake from pastery shop");
        }

        public void InviteFrieds(string[] friends)
        {
            foreach(string friend in friends)
            {
                Console.WriteLine($"Hai {friend}, Greetings of the day! Please come to B'day party in my house");
            }
        }

        public void PrepareFood()
        {
            Console.WriteLine("Food is ordered thru' caterring!");
        }
    }
    internal class Ex17InterfacesConcepts
    {
        static void Main(string[] args)
        {
            IParty party = new BdayParty(); //Luskov's substitution principle. UR base class is instantiated to derived class to promote Runtime poly morphism. 
            party.GetCake();
            party.InviteFrieds(new string[] { "Suresh", "Gopi", "Robert", "Sam" });
            party.PrepareFood();
            Console.WriteLine("\n\n\n");

            party = new MyPersonalParty();
            party.GetCake();
            party.InviteFrieds(new string[] { "Suresh", "Gopi", "Robert", "Sam" });
            party.PrepareFood();

        }
    }
}
