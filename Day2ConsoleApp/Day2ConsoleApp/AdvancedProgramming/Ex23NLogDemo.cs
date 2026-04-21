using System;
using NLog;

namespace AdvancedProgramming
{
    internal class Ex23NLogDemo
    {
        private static readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Info("Application has started");
            try
            {
                DoSomethingImportant();
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
            finally
            {
                logger.Info("Application has closed");
            }
        }

        static void DoSomethingImportant()
        {
            logger.Debug("Entering the DoSomethingImportant function");
            throw new Exception("OOPs! Something went wrong");
        }
    }
}
