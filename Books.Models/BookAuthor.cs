using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Models
{
    public class BookAuthor
    {
        //BookId ve AuthorId isimlerinin yerleri yanlışş!!! Bunu nasıl düzeltebilirim?
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
