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
    public class PublisherService : IPublisherService
    {
        public IPublisherRepository publisherRepository;
        private IMapper mapper;

        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            this.publisherRepository = publisherRepository;
            this.mapper = mapper;
        }

        public int AddPublisher(AddNewPublisherRequest request)
        {
            var newPublisher = request.ConvertToPublisher(mapper);
            publisherRepository.Add(newPublisher);
            return newPublisher.Id;
        }

        public void DeletePublisher(int id)
        {
            publisherRepository.Delete(id);
        }

        public IList<PublisherListResponse> GetAllPublisher()
        {
            var dtoList = publisherRepository.GetAll().ToList();
            // Extension Method
            var result = dtoList.ConvertToListResponse(mapper);
            return result;
        }

        public IList<PublisherListResponse> GetPublisherByPublisherName(string publisherName)
        {
            var publisherDtoList = publisherRepository.GetAll().Where(x => x.Name.Contains(publisherName, StringComparison.OrdinalIgnoreCase)).ToList();
            var result = publisherDtoList.ConvertToListResponse(mapper);
            return result;
        }

        public IList<PublisherListResponse> GetPublisherByBookTitle(string bookTitle)
        {
            var publisherDtoList = publisherRepository.GetAll().Where(x => x.Books.Any(y=>y.Title.Contains(bookTitle, StringComparison.OrdinalIgnoreCase))).ToList();
            var result = publisherDtoList.ConvertToListResponse(mapper);
            return result;
        }

        public PublisherListResponse GetPublisherById(int id)
        {
            Publisher publisher = publisherRepository.GetById(id);
            return publisher.ConvertFromEntity(mapper);
        }

        public int UpdatePublisher(EditPublisherRequest request)
        {
            var publisher = request.ConvertToEntity(mapper);
            int id = publisherRepository.Update(publisher).Id;
            return id;
        }
    }
}
