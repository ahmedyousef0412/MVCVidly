using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models.ViewModels
{
    public class NewMovieViewModel
    {

        public IEnumerable<Genre> Genres { get; set; }

        //public Movie Movie { get; set; }

        public int? Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }


        [Display(Name = "Release Data")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Range(1, 20, ErrorMessage = " The Number In Stock Field Must Between 1 and 20")]
        [Display(Name = "Number In Stock")]
        [Required]
        public byte? NumberInStock { get; set; }


        //[ForeignKey("GenreId")]
        //public Genre Genre { get; set; }



        [Required]
        [Display(Name="Genre")]
        public int GenreId { get; set; }


        public string Title
        {
            get
            {
                //If Id not Equal Zero Open NewMovie With Title [EditMovie] else the Title [New Movie]
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
        public NewMovieViewModel()
        {
            Id = 0;
            NumberInStock = 0;
            ReleaseDate = DateTime.Now;
        }


        // That Mean The Paramter [movie] Carry All Data in this Ctor And
        // I Will Pass It when I Use  That View Model
        public NewMovieViewModel(Movie movie)
        {

            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}