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
        int AddBook(AddNewBookRequest request);
        int UpdateBook(EditBookRequest request);
        void DeleteBook(int id);
    }
}
