using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTest2.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        [HttpPost]
        public ActionResult ContactUs(string name,string message,string email)
        {

            return View();
        }
    }
}