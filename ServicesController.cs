﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reservation.Models;

namespace Reservation.Controllers
{
    public class ServicesController : Controller
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
