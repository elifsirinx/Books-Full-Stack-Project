using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Books.Models
{
    public class Author : IEntity
    {
        public int Id { get ; set ; }

        [Required(ErrorMessage = "Name field can't be empty!")]
        [MinLength(2, ErrorMessage = "Name has to be min 2 characters.")]
        [MaxLength(200, ErrorMessage = "Name has to be min 2 characters.")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Bio { get; set; }

        public virtual IList<BookAuthor> Books { get; set; }

    }
}
