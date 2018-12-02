using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lively.Models;
using System.Data.Entity;
using Lively.ViewModels;

namespace Lively.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); 
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer =  new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            if (customer.ID == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.ID == customer.ID);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeID = customer.MembershipTypeID;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            
            return RedirectToAction("Index","Customer");
        }

        public ActionResult Edit(int ID)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == ID);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel 
            {
                Customer=customer,
                MembershipTypes=_context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c=> c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int ID)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.ID == ID);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}