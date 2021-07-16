using Books.DataAccess.Data;
using Books.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Books.DataAccess.Repositories
{
    public class EFBookRepository : IBookRepository
    {
        private BooksDbContext db;

        public EFBookRepository(BooksDbContext booksDbContext)
        {
            db = booksDbContext;
        }
        public Book Add(Book entity)
        {
            db.Books.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Books.Remove(GetById(id));
            db.SaveChanges();
        }

        public IList<Book> GetAll()
        {
            return db.Books.ToList();
        }

        public Book GetById(int id)
        {
            return db.Books.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IList<Book> GetWithCriteria(Func<Book, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public Book Update(Book entity)
        {
            //Update Publishers set name="?" where id=?
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return entity;
        }
    }
}
