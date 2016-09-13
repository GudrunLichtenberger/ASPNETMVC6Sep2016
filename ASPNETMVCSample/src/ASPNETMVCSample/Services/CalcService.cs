using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETMVCSample.Services
{
    public class CalcService : ICalcService
    {
        public int Add(int x, int y) => x + y;


        public int Subtract(int x, int y) => x - y;

    }
}
