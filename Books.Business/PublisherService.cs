using Books.Business.DataTransferObjects;
using Books.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Business
{
    public class PublisherService : IPublisherService
    {
        public IPublisherRepository publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }
        public IList<PublisherResponseList> GetAllPublisher()
        {
            var dtoList = publisherRepository.GetAll().ToList();
            List<PublisherResponseList> result = new List<PublisherResponseList>();
            dtoList.ForEach(p => result.Add(new PublisherResponseList { 
                Id = p.Id, 
                Name = p.Name 
            }));

            return result;
        }
    }
}
