using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Books.DataAccess.Repositories
{
    public class EFPublisherRepository : IPublisherRepository
    {
        public Publisher Add(Publisher entity)
        {
            throw new NotImplementedException();
        }

        public IList<Publisher> GetAll()
        {
            throw new NotImplementedException();
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
