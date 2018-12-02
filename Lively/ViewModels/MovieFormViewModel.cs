using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lively.Models;
using System.ComponentModel.DataAnnotations;

namespace Lively.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "The Genre Field is Required")]
        public byte? GenreID { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                if ( ID != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
        public MovieFormViewModel()
        {
            ID = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            ID = movie.ID;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreID = movie.GenreID; 
        }

    }
}