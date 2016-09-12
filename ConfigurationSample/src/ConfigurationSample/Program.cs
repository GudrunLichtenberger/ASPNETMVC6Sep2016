using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ConfigurationSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateConfiguration(args);
            ReadConfig();

        }

        private static void ReadConfig()
        {
            string val1 = Config["myconfig"];
            Console.WriteLine(val1);

            string conn1 = Config.GetSection("ConnectionStrings")["DefaultConnection"];
            Console.WriteLine(conn1);
            string conn2 = Config.GetConnectionString("DefaultConnection");
            Console.WriteLine(conn2);

            string sample1 = Config["Sample1"];
            Console.WriteLine(sample1);
        }

        private static void CreateConfiguration(string[] args)
        {
            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("connectionstrings.json", optional: true)
                .AddUserSecrets()   // only in dev-mode
                .AddEnvironmentVariables()
                .AddCommandLine(args).Build();
        }

        public static IConfigurationRoot Config { get; private set; }
    }
}
