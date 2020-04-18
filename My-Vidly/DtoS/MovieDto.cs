using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using My_Vidly.Models;

namespace My_Vidly.DtoS
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public GenreTypeDto Genre { get; set; }

        public byte GenreTypeId { get; set; }

       
        public DateTime ReleaseDate { get; set; }

      
        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
        public int InStock { get; set; }

        public int NumberAvailable { get; set; }
    }
}