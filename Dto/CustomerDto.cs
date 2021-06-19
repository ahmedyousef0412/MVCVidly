using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        

        public int MemberShipTypeId { get; set; }


        public MemberShipTypeDto MemberShipType{ get; set; }


        /* [Min18YearsIfAMember]*/ //This is the custom Validation
        public DateTime? BirthDate { get; set; }
    }
}