namespace TheOldWebAPIService.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BooksModel : DbContext
    {
        public BooksModel()
            : base("name=BooksModel")
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<TheOldWebAPIService.Models.Racer> Racers { get; set; }
    }
}
