using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Game_Arena.Models;
using System.ComponentModel.DataAnnotations;

namespace Game_Arena.ViewModels
{
    public class GameFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Game Game { get; set; }
    }
}