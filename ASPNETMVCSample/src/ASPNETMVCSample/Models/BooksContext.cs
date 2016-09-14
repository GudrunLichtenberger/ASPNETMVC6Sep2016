using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCSample.Models
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
