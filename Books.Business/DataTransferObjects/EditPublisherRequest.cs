using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Books.Business.DataTransferObjects
{
    public class EditPublisherRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to define Publisher Name!!!")]
        public string Name { get; set; }
    }
}
