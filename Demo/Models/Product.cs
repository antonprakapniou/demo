using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? PicturePath { get; set; }

        [Required]
        public double Price { get; set; }
    }
}