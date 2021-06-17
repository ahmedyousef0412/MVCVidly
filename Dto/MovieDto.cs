using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }


        [Display(Name = "Release Data")]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 20, ErrorMessage = " The Number In Stock Field Must Between 1 and 20")]
        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }



        [Required]
        public int GenreId { get; set; }
    }
}