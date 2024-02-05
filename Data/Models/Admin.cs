using System.ComponentModel.DataAnnotations;

namespace FribergsBilar_RazorPages.Data.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
