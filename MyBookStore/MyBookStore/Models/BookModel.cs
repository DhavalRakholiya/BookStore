using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MyBookStore.Enums;
using MyBookStore.Helpers;
using Microsoft.AspNetCore.Http;

namespace MyBookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Title of your book")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Title length must be between 5 to 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter the Author name")]
        public string Author { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string Category { get; set; }

        [Required(ErrorMessage = "Please select Language of your book")]
        public int LanguageId { get; set; }

        [Required(ErrorMessage = "Please Enter the Total Pages")]
        [Display(Name = "Total Pages Of Book")]
        public int? TotalPages { get; set; }

        public string Language { get; set; }

        [Required(ErrorMessage = "Please Choose the cover photo of your book")]
        [Display(Name = "Cover photo of your book")]
        public IFormFile CoverPhoto { get; set; }

        public string CoverImageUrl { get; set; }

        [Required(ErrorMessage = "Please Choose the gallery images of your book")]
        [Display(Name = "Choose the gallery images of your book")]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set;  }
    }
}
