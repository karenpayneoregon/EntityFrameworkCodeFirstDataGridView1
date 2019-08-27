using System;
using System.IO;

namespace ReadEditCustomerWithSpecialClass
{
    public class FileLogger
    {
        public static void Log(string logInfo)
        {
            File.AppendAllText(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,"context.log"), 
                logInfo);
        }
    }
}