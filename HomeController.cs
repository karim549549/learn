using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reservation.Models;
using System.Diagnostics;

namespace Reservation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var json = HttpContext.Session.GetString("Customer");
            Person Customer = JsonConvert.DeserializeObject<Person>(json);
            if (Customer.IsAdmin == false)
                ViewBag.Admin = false;
            else
                ViewBag.Admin = true;
            return View();
        }
    }
}