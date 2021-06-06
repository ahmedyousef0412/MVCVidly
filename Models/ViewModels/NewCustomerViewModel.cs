using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models.ViewModels
{
    public class NewCustomerViewModel
    {


        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }

        public Customeer Customeer { get; set; }
    }
}