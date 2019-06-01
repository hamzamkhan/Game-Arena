using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Game_Arena.Models
{
    public class Game
    {
        //properties
        public int Id { get; set; }
        public string Name { get; set; }

      //  [Display(Name = "Release Date")]
        //public DateTime? ReleaseDate { get; set; }
       

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Number In Stock")]
        
        [Range(1,20,ErrorMessage = "This field should range between 1 & 20")]

        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set;  }
      

        public string Price { get; set; }
    }



    // /game/random
}