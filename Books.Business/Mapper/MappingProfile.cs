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
        }
    }
}
