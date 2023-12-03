using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Threading.Tasks;
using Reservation.Models;

namespace Reservation.Controllers
{
    public class ContactController : Controller
    {
        SqlConnection Connection = new SqlConnection("Server=DESKTOP-L6DHQ4D;Database=reservation;Trusted_Connection=True;TrustServerCertificate=True;");

        SqlCommand Command = null;
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
                        
        [HttpPost]
        public IActionResult SendMessage([FromForm] string Subject, [FromForm] string Message)
        {
            Command = Connection.CreateCommand();
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = "insert into inbox values(@CustomerID,3,@Subject,@Message)";
            var json = HttpContext.Session.GetString("Customer");
            Person Customer = JsonConvert.DeserializeObject<Person>(json);
            Command.Parameters.AddWithValue("@CustomerID", Customer.Id);
            Command.Parameters.AddWithValue("@Subject", Subject);
            Command.Parameters.AddWithValue("@Message", Message);
            using (Connection)
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
            }
            return RedirectToAction("Index");
        }
    }
}
