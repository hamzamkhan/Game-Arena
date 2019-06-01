using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Game_Arena.Models;
using Game_Arena.Dtos;
using AutoMapper;
using System.Data.Entity;


namespace Game_Arena.Controllers.Api
{
    public class GamesController : ApiController
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/games

        public IEnumerable<GameDto> GetGames(string query = null)
        {
            var gamesQuery = _context.Games
                .Include(g => g.Genre)
                .Where(g => g.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                gamesQuery = gamesQuery.Where(g => g.Name.Contains(query));

            return gamesQuery
                .ToList()
                .Select(Mapper.Map<Game, GameDto>);
        }


        //GET /api/games/1
        public IHttpActionResult GetGame(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);

            if (game == null) // if game is not found
            {
                return NotFound();
            }

            else
            {
                return Ok(Mapper.Map<Game, GameDto>(game));
            }
        }

        //POST /api/games
        [HttpPost] //only called with POST request
        public IHttpActionResult CreateGame(GameDto gameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var game = Mapper.Map<GameDto, Game>(gameDto);
                _context.Games.Add(game);
                _context.SaveChanges();

                gameDto.Id = game.Id;
                

                return Created(new Uri(Request.RequestUri + "/" + game.Id), gameDto);
            }
        }

        // PUT /api/games/1
        [HttpPut]
        public IHttpActionResult UpdateGame(int id, GameDto gameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var gameInDb = _context.Games.SingleOrDefault(g => g.Id == id);
                if (gameInDb == null)
                {
                    return NotFound();
                }
                else
                {
                    Mapper.Map(gameDto, gameInDb);
                    //passing existing objects so as to be changed and not creating new object

                    _context.SaveChanges();
                    return Ok(); 
                }
            }
        }

        //DELETE /api/games/1
        [HttpDelete]
        public IHttpActionResult DeleteGame(int id)
        {
            var gameInDb = _context.Games.SingleOrDefault(g => g.Id == id);
            if (gameInDb == null)
            {
                return NotFound();
            }
            else
            {
                _context.Games.Remove(gameInDb);
                _context.SaveChanges();
                return Ok();
            }
        }


    }
}
