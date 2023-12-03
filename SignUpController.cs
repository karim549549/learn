using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Reservation.Models;

namespace Reservation.Controllers
{
    public class SignUpController : Controller
    {
        SqlConnection Connection = new SqlConnection("Server=DESKTOP-L6DHQ4D;Database=reservation;Trusted_Connection=True;TrustServerCertificate=True;");
        SqlCommand Command = null;
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public IActionResult Sign([FromForm] string Username, [FromForm] string Password, [FromForm] string RepeatPassword)
        {
            
        
           
            if (!CheckExistance(Username,Password))
                ViewBag.ErrorMessage = true;
            else
            {   
                Command = Connection.CreateCommand();
                Command.CommandType = System.Data.CommandType.Text;
                Command.CommandText = "insert into person values(@Username,@Password,0)";
                Command.Parameters.AddWithValue("@Username", Username);
                Command.Parameters.AddWithValue("@Password", Password);
                using (Connection)
                {
                    Connection.Open();
                    SqlDataReader reader = Command.ExecuteReader();
                }
                return View("~/Views/Login/Index.cshtml");
            }
            return View("Index");
        }
        public static bool CheckExistance(string Username,string Password) {
            SqlConnection Connection = new SqlConnection("Server=DESKTOP-L6DHQ4D;Database=reservation;Trusted_Connection=True;TrustServerCertificate=True;");
            SqlCommand Command = Connection.CreateCommand();
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = "select * from person where username=@Username and [password]=@Password";
            Command.Parameters.AddWithValue("@Username", Username);
            Command.Parameters.AddWithValue("@Password", Password);
            bool flag = true;
            using (Connection)
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    flag = false;
                }
             
            }
            return flag;
        }

    }
}
