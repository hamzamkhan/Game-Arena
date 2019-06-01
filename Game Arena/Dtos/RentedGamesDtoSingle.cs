using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_Arena.Dtos
{
    public class RentedGamesDtoSingle
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public string HomeAddress { get; set; }


        public int? GameId { get; set; }

        public string GameName { get; set; }
    }
}