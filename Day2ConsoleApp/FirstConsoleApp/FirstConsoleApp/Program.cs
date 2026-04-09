using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RipeSection.Apple.DoSomething();
            RottenSection.Apple.DoSomething();
        }
    }
}

/// <summary>
/// To Understand the concept of namespaces and how they can help avoid naming conflicts in C#.
namespace RipeSection
{
    class Apple
    {
        public static void DoSomething()
        {
            Console.WriteLine("Doing something with a ripe apple.");
        }
    }
}

namespace RottenSection
{
    class Apple
    {
        public static void DoSomething()
        {
            Console.WriteLine("Doing something with a rotten apple.");
        }
    }
}
