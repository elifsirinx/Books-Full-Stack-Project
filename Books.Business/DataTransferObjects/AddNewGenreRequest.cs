using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Books.Business.DataTransferObjects
{
    public class AddNewGenreRequest
    {
        [Required(ErrorMessage = "You have to define Genre Name!!!")]
        public string Name { get; set; }
    }
}
