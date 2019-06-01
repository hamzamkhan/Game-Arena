using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Game_Arena.Models;

using Game_Arena.Dtos;
using AutoMapper;
using System.Net.Mail;
using System.Configuration;
using System.Data.Entity;

namespace Game_Arena.Controllers.Api
{
    public class NewRentedGamesController : ApiController
    {
        public ApplicationDbContext _context;

        public NewRentedGamesController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpGet]
        public IEnumerable<RentedGamesDtoSingle> GetRentedGames(string query = null)
        {
            var rentedGamesQuery = _context.RentedGames
                .Include(r => r.Game).Include(r => r.Customer);
            

            return rentedGamesQuery.Select(Mapper.Map<RentedGames, RentedGamesDtoSingle>);
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentedGamesDto newRental)
        {
            int emailFlag = 0;
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            string gameNames = " ";
            var games = _context.Games.Where(g => newRental.GameIds.Contains(g.Id));
            if (games != null)
            {
                emailFlag = 1;
                foreach (var game in games)
                {
                    if (game.NumberAvailable == 0)
                    {
                        return BadRequest("Game Unavailable");
                    }
                    game.NumberAvailable--;
                    var rental = new RentedGames
                    {
                        Customer = customer,
                        Game = game,
                        GameName = game.Name,
                        HomeAddress = newRental.HomeAddress,
                        Email = newRental.Email,
                        ContactNumber = newRental.ContactNumber
                    };
                    gameNames = gameNames + game.Name;
                    _context.RentedGames.Add(rental);
                }

            }

            else
            {
                return NotFound();
            }

            _context.SaveChanges();


            if(emailFlag == 1)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(ConfigurationManager.AppSettings["senderEmail"]);
                message.To.Add(new MailAddress(newRental.Email));
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                message.Subject = "Game Arena - Rental Received";
                message.Body = "Dear Customer,\nWe have received your rental form including games "+gameNames+" which will be delivered to your address : "+newRental.HomeAddress+". Thank you for dealing with us.\n\nRegards,\nGame Arena.";
                client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["senderEmail"], ConfigurationManager.AppSettings["senderPassword"]);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(message);

            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteRental(int id)
        {
            var rentalInDb = _context.RentedGames.Include(r => r.Game).SingleOrDefault(r => r.Id == id);
            if(rentalInDb == null)
            {
                return NotFound();
            }
            else
            {
                rentalInDb.Game.NumberAvailable++;
                _context.RentedGames.Remove(rentalInDb);
                _context.SaveChanges();
                return Ok();
            }
        }

    }
}
