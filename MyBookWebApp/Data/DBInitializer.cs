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

            context.Languages.AddRange(new Language[]
            {
                new Language{Name="English"},
                new Language{Name="German"},
                new Language{Name="Russian"},
                new Language{Name="Catalan"},
                new Language{Name="Spanish"},
                new Language{Name="Arab"},
            });

            context.Authors.AddRange(new Author[]
            {
                new Author{Name="Neil Gaiman"},
                new Author{Name="Friedrich Nietzsche"},
                new Author{Name="Fiodor Dosteyevsky"},
                new Author{Name="Lev Tolstói"},
                new Author{Name="Josep Pla"},
                new Author{Name="Miguel de Cervantes"},
                new Author{Name="Rafael Marín"},
                new Author{Name="(Anonnymous)"},
            });

            context.Books.AddRange(new Book[]
            {
                new Book{Title="American Gods",
                    AuthorID = context.Authors.First<Author>(au=>au.Name=="Neil Gaiman").ID,
                    LanguageID = context.Languages.First<Language>(la=>la.Name=="English").ID,
                },
                new Book{Title="Anansi Boys",AuthorID = context.Authors.First<Author>(au=>au.Name=="Neil Gaiman").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="English").ID,},
                new Book{Title="Smoke and mirrors",AuthorID = context.Authors.First<Author>(au=>au.Name=="Neil Gaiman").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="English").ID,},
                new Book{Title="Fragile things",AuthorID = context.Authors.First<Author>(au=>au.Name=="Neil Gaiman").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="English").ID,},
                new Book{Title="Thus spoke Zarathustra",AuthorID = context.Authors.First<Author>(au=>au.Name=="Friedrich Nietzsche").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="German").ID,},
                new Book{Title="Beyond Good & Evil",AuthorID = context.Authors.First<Author>(au=>au.Name=="Friedrich Nietzsche").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="German").ID,},
                new Book{Title="Human, All-too human",AuthorID = context.Authors.First<Author>(au=>au.Name=="Friedrich Nietzsche").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="German").ID,},
                new Book{Title="Crime & punishment",AuthorID = context.Authors.First<Author>(au=>au.Name=="Fiodor Dosteyevsky").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="Russian").ID,},
                new Book{Title="Karamazov's brothers",AuthorID = context.Authors.First<Author>(au=>au.Name=="Fiodor Dosteyevsky").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="Russian").ID,},
                new Book{Title="The idiot",AuthorID = context.Authors.First<Author>(au=>au.Name=="Fiodor Dosteyevsky").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="Russian").ID,},
                new Book{Title="Anna Karenina",AuthorID = context.Authors.First<Author>(au=>au.Name=="Lev Tolstói ").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="Russian").ID,},
                new Book{Title="War & peace",AuthorID = context.Authors.First<Author>(au=>au.Name=="Lev Tolstói ").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="Russian").ID,},
                new Book{Title="The death of Ivan Ilyich",AuthorID = context.Authors.First<Author>(au=>au.Name=="Lev Tolstói ").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="Russian").ID,},
                new Book{Title="El quadern gris",AuthorID = context.Authors.First<Author>(au=>au.Name=="Josep Pla").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="Catalan").ID,},
                new Book{Title="Aigua de mar",AuthorID = context.Authors.First<Author>(au=>au.Name=="Josep Pla").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="Catalan").ID,},
                new Book{Title="El quijote",AuthorID = context.Authors.First<Author>(au=>au.Name=="Miguel de Cervantes ").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="Spanish").ID,},
                new Book{Title="Lágrimas de luz",AuthorID = context.Authors.First<Author>(au=>au.Name=="Rafael Marín").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="Spanish").ID,},
                new Book{Title="Thousand and one nights",AuthorID = context.Authors.First<Author>(au=>au.Name=="(Anonnymous)").ID,LanguageID = context.Languages.First<Language>(la=>la.Name=="Arab").ID,},
            });

            context.SaveChanges();
        }
    }
}