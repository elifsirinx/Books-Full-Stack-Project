using Books.DataAccess.Data;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Books.DataAccess.Repositories
{
    public class EFPublisherRepository : IPublisherRepository
    {
        private BooksDbContext db;

        public EFPublisherRepository(BooksDbContext booksDbContext)
        {
            db = booksDbContext;
        }
        public Publisher Add(Publisher entity)
        {
            db.Publishers.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public IList<Publisher> GetAll()
        {
            return db.Publishers.ToList();
        }

        public Publisher GetById(int id)
        {
            return db.Publishers.Find(id);
        }

        public IList<Publisher> GetWithCriteria(Expression<Func<Publisher, bool>> criteria)
        {
            throw new NotImplementedException();
        }
    }
}
