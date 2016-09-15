using ClientApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            var container = new Container(new Uri("http://localhost:4950/odata/"));
            var q = from r in container.Racers
                    where r.Nationality == "Austria"
                    orderby r.Wins descending, r.LastName
                    select r;

            foreach (var r in q)
            {
                Console.WriteLine($"{r.FirstName} {r.LastName}");
            }
            Console.ReadLine();

        }
    }
}
