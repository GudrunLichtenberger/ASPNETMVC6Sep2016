using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DISample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RegisterServices();
            //IGreeting greeting = new GreetingService();
            //HelloController controller = new HelloController(greeting);
            HelloController controller = Container.GetService<HelloController>();
            controller.MyAction1("Katharina");
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IGreeting, GreetingService>();
            services.AddTransient<HelloController>();
            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }
    }
}
