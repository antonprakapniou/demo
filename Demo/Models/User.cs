using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Address { get; set; }
    }
}