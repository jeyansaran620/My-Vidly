using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using My_Vidly.Models;

namespace My_Vidly.viewmodel
{
    public class MovieFormModel
    {
        public List<GenreType> GenreTypes { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Movie name.")]
        public string Name { get; set; }

        [Display(Name = "Genre Type")]
        public byte? GenreTypeId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Range(1, 20)]
        public int? InStock { get; set; }

        public MovieFormModel()
        {
            Id = 0;
            DateAdded= DateTime.Now.Date;
        }
        public MovieFormModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreTypeId = movie.GenreTypeId;
            DateAdded = movie.DateAdded;
            ReleaseDate = movie.ReleaseDate;
            InStock = movie.InStock;
        }
    }
}