using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Game_Arena.Models;
using Game_Arena.ViewModels;
using System.Data.Entity;
using System.Runtime.Caching;
using System.Web.Security;
using System.Web.SessionState;
namespace Game_Arena.Controllers
{
    public class CustomerController : Controller
    {
        //for accessing the database
        private ApplicationDbContext _context;

        public CustomerController()
        {
            //initialization
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };
            return View("CustomerForm", viewModel);
        }

        //Gets called only by Http post and not by get
        
        public ActionResult Save(Customer customer)
        {
            //Checks for validation of the applied annotations
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel); // returns the same form if not valid. 
               
            }
            if (customer.Id == 0)
            {
                //Its a new customer and has to be added.
                _context.Customers.Add(customer);

            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;

                // above four lines OR Mapper.Map(customer, customerInDb)
            }
            _context.SaveChanges();
            ViewBag.Message = customer.Name + " successfully registered.";
            //return RedirectToAction("Index", "Customer");
            return RedirectToAction("Index","Home");
        }
        // GET: Customer
        public ActionResult Index()
        {
            if(Session["Email"] != null && Session["Email"].ToString()=="admin@gamearena.com")
            {
                return View("List");
            }

            else
            {
                return View("ReadOnlyList");
            }
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

      /*  public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel); //override otherwise it will look for a view named Edit which will lead to an exception.
            }
        }
        */
        public ActionResult LoginCustomer()
        {
            return View("Login");
        }


        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            var userInfo = _context.Customers.Single(u => u.Email == customer.Email && u.Password == customer.Password);
            if(userInfo != null)
            {
                var userEmail = customer.Email;
                Session["Id"] = userInfo.Id;
                Session["Email"] = customer.Email;
                Session["Name"] = userInfo.Name;
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is incorrect.");

            }

            return View("Login");
        }

        public ActionResult LoggedIn()
        {
            
            if(Session["Id"] != null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["Id"] = null;
            Session["Email"] = null;
            Session["Name"] = null;
            return RedirectToAction("Index", "Home");
        }


    }
}