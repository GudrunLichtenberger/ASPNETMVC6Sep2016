using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASimpleWebApp.Services
{
    public class SampleService : ISampleService
    {
        public string ToUpper(string s) => s.ToUpper();

    }
}
