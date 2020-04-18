using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using My_Vidly.Models;
using My_Vidly.viewmodel;


namespace My_Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new  ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageCustomers)]
        [Route("Customers/New")]
        public ActionResult New()
        {

            var membershipTypes = _context.MembershipTypes.ToList();

         
            var viewModel = new CustomerFormModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };
            return View("CustomerForm",viewModel);

        }

        [Authorize(Roles = RoleName.CanManageCustomers)]
        [Route("Customers/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormModel
            {
                Customer = customer, 
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);

        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageCustomers)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0)
            _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DOB = customer.DOB;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");

        }

        // GET: Customers
        public ActionResult Index()
        {


            // var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            // var viewModel = new CustomersViewModel
            // {
            //     Customers = customers
            // };

            if (User.IsInRole(RoleName.CanManageCustomers))
                return View("ViewIndex");

            return View("ReadOnlyIndex");

        }


    }
}