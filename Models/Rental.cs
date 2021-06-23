using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {

        public int Id { get; set; }

        public DateTime DataRented { get; set; }

        public DateTime?  DataReturned { get; set; }

        [Required]
        public Customeer Customeer { get; set; }

        [Required]
        public Movie Movie { get; set; }
    }
}