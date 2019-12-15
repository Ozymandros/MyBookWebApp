using MyBookWebApp.Models;
using System;
using System.Linq;

namespace MyBookWebApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MyBookWebAppContext context)
        {
            context.Database.EnsureCreated();

            // Look for any books.
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            context.Books.AddRange(new Book[]
            {
                new Book{Title="American Gods",Author="Neil Gaiman",Language="English"},
                new Book{Title="Anansi Boys",Author="Neil Gaiman",Language="English"},
                new Book{Title="Smoke and mirrors",Author="Neil Gaiman",Language="English"},
                new Book{Title="Fragile things",Author="Neil Gaiman",Language="English"},
                new Book{Title="Thus spoke Zarathustra",Author="Friedrich Nietzsche",Language="German"},
                new Book{Title="Beyond Good & Evil",Author="Friedrich Nietzsche",Language="German"},
                new Book{Title="Human, All-too human",Author="Friedrich Nietzsche",Language="German"},
                new Book{Title="Crime & punishment",Author="Fiodor Dosteyevsky",Language="Russian"},
                new Book{Title="Karamazov's brothers",Author="Fiodor Dosteyevsky",Language="Russian"},
                new Book{Title="The idiot",Author="Fiodor Dosteyevsky",Language="Russian"},
                new Book{Title="Anna Karenina",Author="Lev Tolstói ",Language="Russian"},
                new Book{Title="War & peace",Author="Lev Tolstói ",Language="Russian"},
                new Book{Title="The death of Ivan Ilyich",Author="Lev Tolstói ",Language="Russian"},
                new Book{Title="El quadern gris",Author="Josep Pla",Language="Catalan"},
                new Book{Title="Aigua de mar",Author="Josep Pla",Language="Catalan"},
                new Book{Title="El quijote",Author="Miguel de Cervantes ",Language="Spanish"},
                new Book{Title="Lágrimas de luz",Author="Rafael Marín",Language="Spanish"},
                new Book{Title="Les mil i una nits",Author="(Anonnymous)",Language="Catalan"},
            });

            context.SaveChanges();
        }
    }
}