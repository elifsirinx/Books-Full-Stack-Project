using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Books.Models
{
    public class Book : IEntity
    {
        public int Id { get ; set ; }

        [Required(ErrorMessage = "Name field can't be empty!")]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public string About { get; set; }
        public string ImagePath { get; set; }

        public int PublisherId { get; set; }
        //Navigation Property
        public virtual Publisher Publisher { get; set; }

        public virtual IList<BookAuthor> Authors { get; set; }

        public virtual IList<BookGenre> Genres { get; set; }
    }
}
