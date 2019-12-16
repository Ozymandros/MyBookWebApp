using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookWebApp.Models
{
    public class Language
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
