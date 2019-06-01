using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_Arena.Dtos
{
    public class RentedGamesDto
    {
        public int CustomerId { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public string HomeAddress { get; set; }

        public List<int> GameIds { get; set; }  

        public List<string> GameNames { get; set; }

        public int? GameId { get; set; }
    }
}