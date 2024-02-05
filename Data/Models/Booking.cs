

using System.ComponentModel.DataAnnotations;

namespace FribergsBilar_RazorPages.Data.Models
{
    public class Booking 
    {
        public int BookingId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }

        //Relationship
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
