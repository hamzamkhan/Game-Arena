using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Game_Arena.Models;

namespace Game_Arena.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
//        public DateTime? ReleaseDate { get; set; }




        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }


        [Range(1, 20)]

        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }


        public string Price { get; set; }
    }
}