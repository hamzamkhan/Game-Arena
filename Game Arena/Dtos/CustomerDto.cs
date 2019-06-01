using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Game_Arena.Models;

namespace Game_Arena.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        //use primitive or custom dtos
        [StringLength(255)]
        public string Name { get; set; }

//        public bool IsSubscribeToNewsLetter { get; set; }
        //implictly required because its byte and not nullable(?)
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Minimum14YearsIfAMember]
  //      public DateTime? BirthDate { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}