using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Books.DataAccess.Repositories
{
    public class FakePublisherRepository : IPublisherRepository
    {
        public Publisher Add(Publisher entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Publisher> GetAll()
        {
            return new List<Publisher>
            {
                new Publisher{ Id=1, Name="Kırmızı Kedi Yayınevi"},
                new Publisher{ Id=2, Name="İş Bankası Yayınevi"},
                new Publisher{ Id=3, Name="Can Yayınevi"},
                new Publisher{ Id=4, Name="MEB Yayınevi"}
            };
        }

        public Publisher GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Publisher> GetWithCriteria(Func<Publisher, bool> criteria)
        {
            throw new NotImplementedException();
        }

        

        public Publisher Update(Publisher entity)
        {
            throw new NotImplementedException();
        }
    }
}
