using Books.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Business.DataTransferObjects
{
    public class BookListResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public string About { get; set; }
        public string ImagePath { get; set; }
        public int PublisherId { get; set; }
        

        //public virtual Publisher Publisher { get; set; }
        //public virtual IList<BookAuthor> Authors { get; set; }

    }
}
