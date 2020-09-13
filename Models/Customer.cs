using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Paranoid.Models
{
    public class Customer
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage ="Please enter a name.")]
        [StringLength(255)]
        public string Name { get; set; }
       
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime DOB { get; set; }

        public bool IsSubscibedToNewsLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }
       
        [Display(Name="Membership Type")]
        public byte MemberShipTypeId { get; set; }

    }
}