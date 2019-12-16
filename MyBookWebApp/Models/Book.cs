using System.ComponentModel.DataAnnotations;

namespace MyBookWebApp.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int AuthorID { get; set; }

        [Required]
        public int LanguageID { get; set; }

        public Author Author { get; set; }

        public Language Language { get; set; }
    }
}