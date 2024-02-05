using System.ComponentModel.DataAnnotations;

namespace FribergsBilar_RazorPages.Data.Models
{
    public class OldOrders
    {
        [Key]
        public int OldOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }

    }
}
