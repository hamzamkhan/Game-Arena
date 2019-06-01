using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Game_Arena.Models
{
    public class RentedGames
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Game Game { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string HomeAddress { get; set; }

        [Required]
        public string GameName { get; set; }

    
       
    }
}