using System;
using System.Data;
using System.IO; //used for File IO operations


//Users need to keep track of the flow of the application including happy paths and issues. The flow of the app should not hamper the UI look and feel. 
//"black box Flight recorder" for UR software. As long as things are working smoothly, U ignore them. But issues raise, those logs are often the way to fix any issues and figure out what has happened and scenario of it. 
//In Production level, U dont have IDE or debugging tools. The logs shall give the information on what happened without going to the machine level and verify it.
//It is more like a Post Mortem analysis. 
//It allows in monitoring of the application without a const user looking into it. Even helps in audit trails like who changed and what changed. 
//Logging shall have 5 levels: Noise(Debug/Trace), Normalcy(Information), Concern(Warning), Failure(Error) , Panic(Critical).
//There are many third party Logger libraries that can be used in UR application. They are configurable and maintain industry stds of logging. NLog, Serilog, Log4net are few of the popular Logging libraries.  
namespace AdvancedProgramming
{
    //If U want to log the information to a file.
    static class Logger
    {
        //static class ensures that only static methods shall be there and will not require any object while calling the methods. static Methods are called by their Classname.
        static readonly string fileName = $"DetailedLog_{DateTime.Now.ToString("dd-MM-yyyy")}.txt";//Logging to a file based on the date on which U Ran the application.  
        public static void Information(string message)
        {
            var line = $"[{DateTime.Now}]: {message}\n";
            File.AppendAllText(fileName, line);//Opens an existing file, if not found, creates a new file and writes/appends to it. 
        }

        public static void Error(string message)
        {
            var line = $"[{DateTime.Now}]: {message}\n";
            File.AppendAllText(fileName, line);
        }
    }
    internal class Ex22LoggingExample
    {
        static void Main(string[] args)
        {
            Logger.Information("Application has started");
            Logger.Information($"Reading all the cmd line args:");
            foreach(var arg in args)
            {
                Logger.Information(arg);
            }
        }
    }
}
