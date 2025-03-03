using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var memberShipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = memberShipTypes
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(CustomerFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.MembershipTypes = _context.MembershipTypes.ToList();
                return View("CustomerForm", model);
            }

            if(model.Customer.Id == 0)
            {
                _context.Customers.Add(model.Customer);
            }
            else
            {
                var cust = _context.Customers.SingleOrDefault(x => x.Id == model.Customer.Id);
                if(cust != null)
                {
                    cust.Name = model.Customer.Name;
                    cust.BirthDate = model.Customer.BirthDate;
                    cust.IsSubscribedToNewsLetter = model.Customer.IsSubscribedToNewsLetter;
                    cust.MembershipTypeId = model.Customer.MembershipTypeId;
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
                
            };

            return View("CustomerForm", viewModel);
        }

        [OutputCache(Duration = 0,VaryByParam ="*", NoStore =true)]
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
    }
}