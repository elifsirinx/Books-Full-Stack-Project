using Books.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Business
{
    public interface IUserService
    {
        User GetUser(string userName, string password); 
    }
}
