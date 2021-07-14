using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Books.Models
{
    public class Publisher : IEntity
    {
        public int Id { get ; set ; }

        [Required(ErrorMessage = "Name field can't be empty!")]
        public string Name { get; set; }

        public virtual IList<Book> Books { get; set; }

        
    }
}
