using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lively.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Select Genre")]
        [Required(ErrorMessage = "The Genre Field is Required")]
        public byte GenreID { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name="Number In Stock")]
        [Required]
        [Range(1,20)]
        public byte NumberInStock { get; set; }
    }
}