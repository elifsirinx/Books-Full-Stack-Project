using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Models
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Book Book { get; set; }
    }
}
