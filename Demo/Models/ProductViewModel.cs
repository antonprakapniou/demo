namespace Demo.Models
{
    public class ProductViewModel
    {
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public string? PicturePath { get; set; }
        public double Price { get; set; }
    }
}