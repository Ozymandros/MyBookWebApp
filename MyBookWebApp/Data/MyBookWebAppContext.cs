using Microsoft.EntityFrameworkCore;
using MyBookWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookWebApp.Data
{
    public class MyBookWebAppContext : DbContext
    {
        public MyBookWebAppContext(DbContextOptions<MyBookWebAppContext> options)
            : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Language> Languages { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BooksDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasIndex(bo => bo.Title).IsUnique();//.ToTable(nameof(Book));
            modelBuilder.Entity<Author>().HasIndex(au => au.Name).IsUnique();//.ToTable(nameof(Author));
            modelBuilder.Entity<Language>().HasIndex(la => la.Name).IsUnique();//.ToTable(nameof(Language));
        }

    }
}
