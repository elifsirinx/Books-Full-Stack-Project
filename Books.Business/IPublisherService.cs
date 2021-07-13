using Books.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Business
{
    public interface IPublisherService
    {
        IList<PublisherResponseList> GetAllPublisher();

    }
}
