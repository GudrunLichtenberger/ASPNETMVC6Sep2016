using ClientApp.Models;
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
            Console.WriteLine("Press return to make the request");
            Console.ReadLine();
            Run();
            Console.WriteLine("Press return to exit");
            Console.ReadLine();

        }

        private static async void Run()
        {
            APIV1 proxy = new APIV1();
            proxy.BaseUri = new Uri("http://localhost:7226/");
            IList<BookChapter> chapters = await proxy.ApiBookChaptersGetAsync();
            foreach (var chapter in chapters)
            {
                Console.WriteLine($"{chapter.Title}, pages: {chapter.Pages}");
            }
        }
    }
}
