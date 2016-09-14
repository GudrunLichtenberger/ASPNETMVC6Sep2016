using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreSample1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateABook();
        }

        private static void CreateABook()
        {
            try
            {
                using (var context = new BooksContext())
                { 
                    bool created = context.Database.EnsureCreated();
                    Console.WriteLine($"created database {created} ");
                    context.Books.Add(new Book { Title = "Professional C# 6", Publisher = "Wrox Press" });
                    int changed = context.SaveChanges();
                    Console.WriteLine($"changed {changed} records");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
