using Books.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Business
{
    public interface IBookService
    {
        IList<BookListResponse> GetAllBook();
        BookListResponse GetBookById(int id);
    }
}
