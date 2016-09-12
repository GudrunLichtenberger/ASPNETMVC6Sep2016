using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LoggerFactory factory = new LoggerFactory();
            var logger = factory.AddConsole().AddDebug().CreateLogger<Program>();
            logger.LogInformation("info message");
        }
    }
}
