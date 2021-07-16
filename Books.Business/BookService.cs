using AutoMapper;
using Books.Business.DataTransferObjects;
using Books.Business.Extensions;
using Books.DataAccess.Repositories;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Business
{
    public class BookService : IBookService
    {
        private IBookRepository bookRepository;
        private IMapper mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public int AddBook(AddNewBookRequest request)
        {
            var newBook = request.ConvertToBook(mapper);
            bookRepository.Add(newBook);
            return newBook.Id;
        }

        public void DeleteBook(int id)
        {
            bookRepository.Delete(id);
        }

        public IList<BookListResponse> GetAllBook()
        {
            var dtoList = bookRepository.GetAll().ToList();
            // Extension Method
            var result = dtoList.ConvertToListResponse(mapper);
            return result;
        }

        public BookListResponse GetBookById(int id)
        {
            Book book = bookRepository.GetById(id);
            return book.ConvertFromEntity(mapper);
        }

        public int UpdateBook(EditBookRequest request)
        {
            var book = request.ConvertToEntity(mapper);
            int id = bookRepository.Update(book).Id;
            return id;
        }
    }
}
