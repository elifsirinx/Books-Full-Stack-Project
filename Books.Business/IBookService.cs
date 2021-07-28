using Books.Business.DataTransferObjects;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Business
{
    public interface IBookService
    {
        IList<BookListResponse> GetAllBook();
        IList<BookListResponse> GetBookByPublisherName(string publisherName);
        IList<BookListResponse> GetBookByAuthorName(string AuthorName);
        IList<BookListResponse> GetBookByBookTitle(string BookTitle);
        IList<BookListResponse> GetBookByBookGenreId(int genreId);
        BookListResponse GetBookById(int id);
        int AddBook(AddNewBookRequest request);
        int UpdateBook(EditBookRequest request);
        void DeleteBook(int id);
    }
}
