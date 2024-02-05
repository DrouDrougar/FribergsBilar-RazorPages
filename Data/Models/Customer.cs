using System.ComponentModel.DataAnnotations;

namespace FribergsBilar_RazorPages.Data.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string? Address { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //Relationships
        public virtual List<Booking> Bookings { get; set; }

    }
}
