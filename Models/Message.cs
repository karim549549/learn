namespace Reservation.Models
{
    public class Inbox
    {
         public int Id { get; set; }
         public int CustomerId {  get; set; }
         public string Message {  get; set; }
         public string Subject { get; set; }    
      
    }
}
