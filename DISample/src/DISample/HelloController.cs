using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DISample
{
    public class HelloController
    {
        private readonly IGreeting _greetingService;
        public HelloController(IGreeting greetingService)
        {
            _greetingService = greetingService;
        }

        public void MyAction1(string name)
        {
            Console.WriteLine(_greetingService.Hello(name));
        }
    }
}
