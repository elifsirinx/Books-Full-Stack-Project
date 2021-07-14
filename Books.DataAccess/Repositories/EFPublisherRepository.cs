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
            throw new NotImplementedException();
        }

        public IList<Publisher> GetAll()
        {
            return db.Publishers.ToList();
        }

        public Publisher GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Publisher> GetWithCriteria(Expression<Func<Publisher, bool>> criteria)
        {
            throw new NotImplementedException();
        }
    }
}
