using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
namespace AdvancedProgramming
{
    internal class Ex24SerilogDemo
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()//Lowest level
                .WriteTo.Console()
                .WriteTo.File("logs/SerilogInfo.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7)//Keeps only the last 7 days of logs. 
                .CreateLogger();

            try
            {
                Log.Information("Application is going to start");

                int result = AddFunc(13, 12);
                Log.Information("The Added value is " + result);
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "The App failed to execute properly");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        private static int AddFunc(int v1, int v2)
        {
            Log.Debug("Processing Adding Functionatlity for {0} and {1}", v1, v2);
            return v1 + v2;
        }
    }
}
