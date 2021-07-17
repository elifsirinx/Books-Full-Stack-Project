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

        public void Delete(int id)
        {
            db.Publishers.Remove(GetById(id));
            db.SaveChanges();
        }

        public IList<Publisher> GetAll()
        {
            return db.Publishers.ToList();
        }

        public Publisher GetById(int id)
        {
            return db.Publishers.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IList<Publisher> GetWithCriteria(Func<Publisher, bool> criteria)
        {
            throw new NotImplementedException();
        }


        public Publisher Update(Publisher entity)
        {
            //Update Publishers set name="?" where id=?
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return entity;
        }
    }
}
