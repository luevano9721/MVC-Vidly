using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MVC2._0.Models;
using MVC2._0.ViewModels;

namespace MVC2._0.Controllers
{
    
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();

            var viewModel= new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipType
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id==0)
            {
                _context.Customers.Add(customer);
                
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            
            _context.SaveChanges();
            return RedirectToAction("index","Customers");
        }
        //List<Customer> customers = new List<Customer>
        //{
        //    new Customer{ Name = "Jahaziel Rosales", id=1},
        //    new Customer{ Name = "Monica Luevano", id=2}
        //};
        // GET: Customers
        public ActionResult index()
        {
            //var customers = _context.Customers
            //    .Include(c=>c.MembershipType)
            //    .ToList();
           
            return View(/*customers*/);
        }
      //  [Route("Customers/Details/{id:regex(\\d{1}):range(1,2)}")]
        public ActionResult Details(int id)
        {

            var customerSelected = _context.Customers.Include("MembershipType")
                .SingleOrDefault(x =>x.Id==id);

            if (customerSelected == null) 
                return HttpNotFound();

            return View(customerSelected);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer==null)
            {
                return HttpNotFound();
            }

            var viewModel=new CustomerFormViewModel
            {
                Customer=customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}