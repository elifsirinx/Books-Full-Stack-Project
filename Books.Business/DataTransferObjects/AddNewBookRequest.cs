using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Books.Business.DataTransferObjects
{
    public class AddNewBookRequest
    {

        [Required(ErrorMessage = "Title field can't be empty!")]
        [MinLength(2, ErrorMessage = "Title has to be min 2 characters.")]
        [MaxLength(200, ErrorMessage = "Title has to be min 2 characters.")]
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public decimal? Rating { get; set; }
        public string About { get; set; }
        public string ImagePath { get; set; }

        public int PublisherId { get; set; }
    }
}
