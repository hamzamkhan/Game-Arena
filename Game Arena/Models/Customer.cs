using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Game_Arena.Models
{
    public class Customer
    {
        public int Id { get; set; }


        //overriding convention
       // [Required(ErrorMessage = "Please enter customer's name.")] //overrides default validation message.
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

       // public bool IsSubscribeToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }


        //implictly required because its byte and not nullable(?)
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        //[Display(Name = "Date of birth")]
        //[Minimum14YearsIfAMember]
        //public DateTime? BirthDate { get; set; }

        [Required]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }


}