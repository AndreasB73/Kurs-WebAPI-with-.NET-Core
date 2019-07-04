using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02.Models
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // fluent API - customize mapping
            modelBuilder.Entity<Book>().Property(b => b.Title).HasMaxLength(50).IsRequired(false);
            modelBuilder.Entity<Book>().Property(b => b.Publisher).HasMaxLength(25).IsRequired(false);

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Professional C# 6", Publisher = "Wrox Press" },
                new Book { BookId = 2, Title = "Professional C# 7", Publisher = "Wrox Press" }
            );
        }
    }
}
