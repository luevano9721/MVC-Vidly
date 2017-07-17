using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC2._0.Models;

namespace MVC2._0.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }


        [Required]
        [Display(Name = "In Stock")]
        //[Range(1,20)]
        public byte? InStock { get; set; }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            InStock = movie.InStock;
            GenreId = movie.GenreId;

        }

        public MovieFormViewModel()
        {
            Id = 0;

        }
    }
}