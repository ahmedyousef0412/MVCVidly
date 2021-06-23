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

        [Range(1,20 ,ErrorMessage = " The Number In Stock Field Must Between 1 and 20")]
        [Display (Name = "Number In Stock")]
        public byte NumberInStock { get; set; }


        public byte NumberAvailable { get; set; }


        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        
        
        [Required]
        public int GenreId { get; set; }
    }

}