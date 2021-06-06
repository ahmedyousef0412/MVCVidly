using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }


        [Required] 
        [StringLength(255)] 
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }


        [Display (Name = "Release Data")]
        public DateTime ReleaseDate { get; set; }


        [Display (Name = "Number In Stock")]
        public byte NumberInStock { get; set; }


        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        
        
        [Required]
        public int GenreId { get; set; }
    }
}