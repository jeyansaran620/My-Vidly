using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Vidly.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rental
        [Route("Rentals/New")]
        public ActionResult New()
        {
            return View("NewRentalForm");
        }
    }
}