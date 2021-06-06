using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customeer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name="MemberShip Type")]
        public MemberShipType MemberShipType { get; set; }
        public int MemberShipTypeId { get; set; }
       [Display (Name="Date Of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}