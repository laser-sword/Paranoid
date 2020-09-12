using Paranoid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Paranoid.ViewModels;

namespace Paranoid.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()

        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New() {
            var customer = new Customer();
            var membershipTypes = _context.MemberShipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer) {

            if (customer.Id == 0)
                _context.Customers.Add(customer);

            else {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DOB = customer.DOB;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsSubscibedToNewsLetter = customer.IsSubscibedToNewsLetter;
            }

         
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ActionResult Index()
        {

            var customers = _context.Customers.Include(c => c.MemberShipType).ToList(); 
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
        };

            return View("CustomerForm", viewModel);

        }


            //private IEnumerable<Customer> GetCustomers()
            //{
            //    return new List<Customer>
            //    {
            //        new Customer { Id = 1, Name="Dumbass one!"},
            //        new Customer { Id=2, Name="Dumbass too"}
            //    };
            //}
    }
    
}
