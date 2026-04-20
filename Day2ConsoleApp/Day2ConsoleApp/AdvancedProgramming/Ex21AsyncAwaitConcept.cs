using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//If U R working in a multi threaded UI based applications, and want to make UR App responsive, then we use the concept of async and await.
//If a Thread is taking longer time to complete or sitting idle/waiting for a slow task, the thread is freed up to do other work until the task is completed. 
//If a File download is taking a longer time than expected, the Main thread should be free enough to print other messages or handle inputs from the user without waiting for the file to get downloaded..
//The Functions that handle such scenarios are called async functions. 
//Task is an objct that represents an operation. 

//the async keyword is used to notify users that this function is asynchronous. it does not automatically run a method on a background thread. its main purpose is to use the await keywork in it. 
//await makes the .NET runtime check for the task completion. if not completed, it suspends the method and control returns to the caller. When the task is finished, the method resumes from where it was left off. 
//Use this for UI event handlers where the UI shall not wait for the functionality to complete. 
namespace AdvancedProgramming
{
    internal class Ex21AsyncAwaitConcept
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("1. Starting the application....");

            //We start the task, but dont wait to complete. 
            //This allows the next line of code to execute without waiting for download to complete. 
            Task<string> downloadingTask = DownloadDataAsync();

            Console.WriteLine("2. while downloading, I will do other things...");
            PerformBackgroundwork();

            //When U want the result, U will ask the system to wait till the result comes.
            string result = await downloadingTask;

            Console.WriteLine($"3. Downlowd is completed, the data recieved is {result}");
        }

        static async Task<string> DownloadDataAsync()
        {
            Console.WriteLine("(Connecting to the server.........)");

            await Task.Delay(5000);//task.Delay is async version of Thread.Sleep. It simply sets the timer and releases the thread unlik Sleep where it blocks the thread. Tells the thread "GO do other work, and come back after 5 secs).

            return "Sample Data recieved";
        }

        static void PerformBackgroundwork()
        {
            Console.WriteLine("Cleaning up the temporary files....");
            Thread.Sleep(7000);//blocking...
        }
    }
}
