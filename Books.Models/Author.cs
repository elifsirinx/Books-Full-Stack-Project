using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Models
{
    public class Author : IEntity
    {
        public int Id { get ; set ; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Bio { get; set; }

        public virtual IList<BookAuthor> Books { get; set; }

    }
}
