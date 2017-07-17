using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC2._0.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        
        [Required]
        [Display(Name = "In Stock")]
        [Range(1,20)]
        public byte InStock { get; set; }



    }


}