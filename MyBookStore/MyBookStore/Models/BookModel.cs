using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyBookStore.Models
{
    public class BookModel
    {

        [DataType(DataType.EmailAddress)]
        public string MyField { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter the Title of your book")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Title length must be between 5 to 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter the Author name")]
        public string Author { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string Category { get; set; }

        public string Language { get; set; }

        [Required(ErrorMessage = "Please Enter the Total Pages")]
        [Display(Name = "Total Pages Of Book")]
        public int? TotalPages { get; set; }
    }
}
