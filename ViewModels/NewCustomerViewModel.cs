using Paranoid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paranoid.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}