using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Models
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
        public Book Book { get; set; }
    }
}
