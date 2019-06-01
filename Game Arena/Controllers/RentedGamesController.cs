using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_Arena.Controllers
{
    public class RentedGamesController : Controller
    {
        // GET: RentedGames
        public ActionResult New()
        {
            if (Session["Id"] != null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("LoginCustomer", "Customer");
            }
        }

        public ActionResult List()
        {
            if(Session["Id"]!=null)
            {
                if (Session["Email"].ToString() == "admin@gamearena.com")
                {
                    return View("List");
                }
                else
                {
                    return RedirectToAction("LoginCustomer", "Customer");

                }
            }

            else
            {
                return RedirectToAction("LoginCustomer", "Customer");

            }
        }
    }
}