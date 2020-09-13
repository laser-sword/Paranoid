using Paranoid.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Paranoid.DTOs
{
    public class CustomerDTO
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

     
        //[Min18YearsIfAMember]
        public DateTime? DOB { get; set; }

        public bool IsSubscibedToNewsLetter { get; set; }
  

      
        public byte MemberShipTypeId { get; set; }
    }
}