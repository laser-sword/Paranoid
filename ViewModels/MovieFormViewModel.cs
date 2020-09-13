using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Paranoid.Models;

namespace Paranoid.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        
        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
     
        [Display(Name="Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Required]
        public int? Stock { get; set; }

        public string Title
        {
            get {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie) {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenreId = movie.GenreId;
        }

    }
}