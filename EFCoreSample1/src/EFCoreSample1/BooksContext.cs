using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSample1
{
    public class BooksContext : DbContext
    {
        public BooksContext()
        {

        }

        public BooksContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=Books4;trusted_connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().Property<string>("Title").HasMaxLength(40);
        }

        public DbSet<Book> Books { get; set; }
    }
}
