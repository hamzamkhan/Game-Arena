using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game_Arena.Models
{
    public class MembershipType
    {
        [Required]
        public string Name { get; set; }
        public byte Id { get; set; }
        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }


        //readonly in order to prevent change.
        // could've used enum but requires casting in Member14 class which is an overhead.
        public static readonly byte Unknown = 0; 
        public static readonly byte PayAsYouGo = 1;
    }
}