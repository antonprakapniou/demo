namespace Demo.Models
{
    public class Basket
    {
        public List<ProductWithCount>? Products { get; set; }
        public int TotalCount { get; set; }
        public double TotalPrice { get; set; }

        public Basket()
        {
            Products=new();
        }
    }
}