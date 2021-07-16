using AutoMapper;
using Books.Business.DataTransferObjects;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Publisher, PublisherListResponse>().ReverseMap();
            CreateMap<Publisher, AddNewPublisherRequest>().ReverseMap();
            CreateMap<Publisher, EditPublisherRequest>().ReverseMap();

            CreateMap<Book, BookListResponse>().ReverseMap();
            CreateMap<Book, AddNewBookRequest>().ReverseMap();
            CreateMap<Book, EditBookRequest>().ReverseMap();

        }
    }
}
