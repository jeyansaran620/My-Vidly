using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Movie name.")]
        public string Name { get; set; }

        public GenreType Genre { get; set; }

        [Display(Name = "Genre Type")]
        public byte GenreTypeId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Range(1,20)]
        public int InStock { get; set; }

    }

}