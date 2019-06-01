using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Game_Arena.Models; //explicitly added
using Game_Arena.ViewModels;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Game_Arena.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games

        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new GameFormViewModel
            {
                Genres = genres,
                Game = new Game()
            };
            return View("GameForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Game game)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new GameFormViewModel
                {
                    Game = game,
                    Genres = _context.Genres.ToList()
                };
                return View("GameForm", viewModel);
            }
            if (game.Id == 0)
            {
                game.NumberAvailable = game.NumberInStock;
                _context.Games.Add(game);
            }
            else
            {
                var gameInDb = _context.Games.Single(g => g.Id == game.Id);
                gameInDb.Name = game.Name;
                gameInDb.GenreId = game.GenreId;
                gameInDb.NumberInStock = game.NumberInStock;
                gameInDb.Price = game.Price;
                gameInDb.NumberAvailable = game.NumberAvailable;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Games");
        }
        //when navigate to games
        // ? makes it nullable
        public ActionResult Index()
        {
            if (Session["Email"] != null)
            {
                if(Session["Email"].ToString() == "admin@gamearena.com")
                {
                    return View("List");
                }
                else
                {
                    return View("ReadOnlyList");
                }
            }
            else
            {
                return View("ReadOnlyList");
            }
        }

        public ActionResult Details(int id)
        {
            var games = _context.Games.Include(g => g.Genre).SingleOrDefault(g => g.Id == id);

            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);

        }

        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);
            if (game == null)
            {
                return HttpNotFound();
            }

            else
            {
                var viewModel = new GameFormViewModel

                {
                    Game = game,
                    Genres = _context.Genres.ToList()
                };
                return View("GameForm", viewModel);
            }
        }


        //attribute routing
        // : in month represent its constraints
        /*
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }*/
    }
}