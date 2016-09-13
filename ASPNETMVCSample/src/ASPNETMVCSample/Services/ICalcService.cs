using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETMVCSample.Services
{
    public interface ICalcService
    {
        int Add(int x, int y);
        int Subtract(int x, int y);
    }
}
