using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Reservation.Models;
using Newtonsoft.Json;


namespace Reservation.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection Connection = new SqlConnection("Server=DESKTOP-L6DHQ4D;Database=reservation;Trusted_Connection=True;TrustServerCertificate=True;");

        SqlCommand Command = null;
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Login([FromForm] string Username, [FromForm] string Password)
        {
            Command = Connection.CreateCommand();
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = "select * from person where username=@Username and [password]=@Password";
            Command.Parameters.AddWithValue("@Username", Username);
            Command.Parameters.AddWithValue("@Password", Password);
            Person customer = new Person();
            using (Connection)
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    customer.Id = reader.GetInt32(reader.GetOrdinal("id"));
                    customer.Username = reader["username"].ToString();
                    customer.Password = reader["password"].ToString();
                    if (reader.GetInt32(reader.GetOrdinal("isadmin")) == 0)
                        customer.IsAdmin = false;
                    else
                        customer.IsAdmin = true;
                }
            }
            if (customer.Username != null)
            {
                var json = JsonConvert.SerializeObject(customer);
                HttpContext.Session.SetString("Customer", json);
                return RedirectToAction("Index","Home");
            }
            else
            { 
                ViewBag.ErrorMessage = true;
                return View("Index");
            }
        }
    }
}
