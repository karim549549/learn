using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Reservation.Models;
using System.Collections.Generic;

namespace Reservation.Controllers
{
    public class DashController : Controller
    {
        public IActionResult Index()
        {
            var json = HttpContext.Session.GetString("Customer");
            Person Customer = JsonConvert.DeserializeObject<Person>(json);
            if (Customer.IsAdmin == false)
                ViewBag.Admin = false;
            else
                ViewBag.Admin = true;
            MessageList messages = new MessageList();
            messages.Messages = GetData();
            return View("Index", messages);
        }
        public static List<Inbox> GetData()
        {
            SqlConnection Connection = new SqlConnection("Server=DESKTOP-L6DHQ4D;Database=reservation;Trusted_Connection=True;TrustServerCertificate=True;");

            SqlCommand Command = Connection.CreateCommand();
            List<Inbox> inboxList = new List<Inbox>();
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = "select * from inbox where adminid=3";

      
            using (Connection)
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                while (reader.Read())
                {
                    Inbox Message = new Inbox();
                    Message.Id = reader.GetInt32(reader.GetOrdinal("id"));
                    Message.CustomerId = reader.GetInt32(reader.GetOrdinal("customerid"));
                    Message.Subject = reader["subject"].ToString();
                    Message.Message = reader["message"].ToString();
                    inboxList.Add(Message);
                }

            }
            return inboxList;
        }
    }
}
