using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCoreSample1;

namespace EFCoreSample1.Migrations
{
    [DbContext(typeof(BooksContext))]
    [Migration("20160914094807_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreSample1.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Publisher")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 40);

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });
        }
    }
}
