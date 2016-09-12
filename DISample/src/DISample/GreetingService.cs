using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DISample
{
    public class GreetingService : IGreeting
    {
        public string Hello(string name) => $"Hello, {name}";

    }
}
