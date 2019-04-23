using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            //var customer = new Customer()
            //{
            //    Name = "John Doe"
            //};

            var customers = new List<Customer>
            {
                new Customer{Name="John Doe",Id=1},
                new Customer{Name="John Smith",Id=2}
            };

            return View(customers);
        }
    }
}