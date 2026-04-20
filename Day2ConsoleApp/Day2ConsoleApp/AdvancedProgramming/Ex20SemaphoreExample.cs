using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedProgramming
{
    internal class Ex20SemaphoreExample
    {
        //U want to allow only 3 threads to enter at once..
        static SemaphoreSlim _gate = new SemaphoreSlim(3);
        static async Task Main(string[] args)
        {

            Task[] tasks = new Task[10];
            for(int i = 0; i < 10; i++)
            {
                int id = i;
                
                tasks[i] = Task.Run(() => AccessResource(id));//Run is executing parallelly...
            }
            Console.WriteLine("The total no parallel activities going on: " + Process.GetCurrentProcess().Threads.Count);
            await Task.WhenAll(tasks);//Make the Main program wait till all the tasks are completed. 
        }

        static void AccessResource(int id)
        {
            Console.WriteLine($"Thread {id} is waiting...");
            _gate.Wait();//Entrance

            Console.WriteLine($"Thread { id} entered the gate!");
            Thread.Sleep(2000);

            Console.WriteLine($"Thread {id} is leaving....");
            _gate.Release();//Exit..
        }
    }
}
