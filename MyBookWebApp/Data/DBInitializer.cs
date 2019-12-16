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

            using var transaction = context.Database.BeginTransaction();

            // Look for any books.
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            var languages = new Language[]
            {
                new Language{Name="English"},
                new Language{Name="German"},
                new Language{Name="Russian"},
                new Language{Name="Catalan"},
                new Language{Name="Spanish"},
                new Language{Name="Arab"},
            };
            context.Languages.AddRange(languages);

            var authors = new Author[]
             {
                new Author{Name="Neil Gaiman"},
                new Author{Name="Friedrich Nietzsche"},
                new Author{Name="Fiodor Dosteyevsky"},
                new Author{Name="Lev Tolstói"},
                new Author{Name="Josep Pla"},
                new Author{Name="Miguel de Cervantes"},
                new Author{Name="Rafael Marín"},
                new Author{Name="(Anonnymous)"},
             };
            context.Authors.AddRange(authors);

            context.SaveChanges();

            context.Books.AddRange(new Book[]
            {
                new Book{Title="American Gods",
                    AuthorID = authors.Single<Author>(au=>au.Name=="Neil Gaiman").ID,
                    LanguageID = languages.Single<Language>(la=>la.Name=="English").ID,
                },
                new Book{Title="Anansi Boys",AuthorID = authors.Single<Author>(au=>au.Name=="Neil Gaiman").ID,LanguageID = languages.Single<Language>(la=>la.Name=="English").ID,},
                new Book{Title="Smoke and mirrors",AuthorID = authors.Single<Author>(au=>au.Name=="Neil Gaiman").ID,LanguageID = languages.Single<Language>(la=>la.Name=="English").ID,},
                new Book{Title="Fragile things",AuthorID = authors.Single<Author>(au=>au.Name=="Neil Gaiman").ID,LanguageID = languages.Single<Language>(la=>la.Name=="English").ID,},
                new Book{Title="Thus spoke Zarathustra",AuthorID = authors.Single<Author>(au=>au.Name=="Friedrich Nietzsche").ID,LanguageID = languages.Single<Language>(la=>la.Name=="German").ID,},
                new Book{Title="Beyond Good & Evil",AuthorID = authors.Single<Author>(au=>au.Name=="Friedrich Nietzsche").ID,LanguageID = languages.Single<Language>(la=>la.Name=="German").ID,},
                new Book{Title="Human, All-too human",AuthorID = authors.Single<Author>(au=>au.Name=="Friedrich Nietzsche").ID,LanguageID = languages.Single<Language>(la=>la.Name=="German").ID,},
                new Book{Title="Crime & punishment",AuthorID = authors.Single<Author>(au=>au.Name=="Fiodor Dosteyevsky").ID,LanguageID = languages.Single<Language>(la=>la.Name=="Russian").ID,},
                new Book{Title="Karamazov brothers",AuthorID = authors.Single<Author>(au=>au.Name=="Fiodor Dosteyevsky").ID,LanguageID = languages.Single<Language>(la=>la.Name=="Russian").ID,},
                new Book{Title="The idiot",AuthorID = authors.Single<Author>(au=>au.Name=="Fiodor Dosteyevsky").ID,LanguageID = languages.Single<Language>(la=>la.Name=="Russian").ID,},
                new Book{Title="Anna Karenina",AuthorID = authors.Single<Author>(au=>au.Name=="Lev Tolstói").ID,LanguageID = languages.Single<Language>(la=>la.Name=="Russian").ID,},
                new Book{Title="War & peace",AuthorID = authors.Single<Author>(au=>au.Name=="Lev Tolstói").ID,LanguageID = languages.Single<Language>(la=>la.Name=="Russian").ID,},
                new Book{Title="The death of Ivan Ilyich",AuthorID = authors.Single<Author>(au=>au.Name=="Lev Tolstói").ID,LanguageID = languages.Single<Language>(la=>la.Name=="Russian").ID,},
                new Book{Title="El quadern gris",AuthorID = authors.Single<Author>(au=>au.Name=="Josep Pla").ID,LanguageID = languages.Single<Language>(la=>la.Name=="Catalan").ID,},
                new Book{Title="Aigua de mar",AuthorID = authors.Single<Author>(au=>au.Name=="Josep Pla").ID,LanguageID = languages.Single<Language>(la=>la.Name=="Catalan").ID,},
                new Book{Title="El quijote",AuthorID = authors.Single<Author>(au=>au.Name=="Miguel de Cervantes").ID,LanguageID = languages.Single<Language>(la=>la.Name=="Spanish").ID,},
                new Book{Title="Lágrimas de luz",AuthorID = authors.Single<Author>(au=>au.Name=="Rafael Marín").ID,LanguageID = languages.Single<Language>(la=>la.Name=="Spanish").ID,},
                new Book{Title="Thousand and one nights",AuthorID = authors.Single<Author>(au=>au.Name=="(Anonnymous)").ID,LanguageID = languages.Single<Language>(la=>la.Name=="Arab").ID,},
            });

            context.SaveChanges();

            transaction.Commit();
        }
    }
}