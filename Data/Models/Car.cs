
using System.ComponentModel.DataAnnotations;

namespace FribergsBilar_RazorPages.Data.Models
{
    public class Car 
    {
        //The car table ID Key
        public int CarId { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Price { get; set; }

        public string? ImagePath1 { get; set; }

        public string? ImagePath2 { get; set; }

        public string? ImagePath3 { get; set; }

        public bool IsBooked { get; set; } = false;

    }
}
