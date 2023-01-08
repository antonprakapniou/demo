namespace Demo.Models
{
    public class UserViewModel
    {
        public class User
        {
            public Guid UserId { get; set; }
            public string? Name { get; set; }
            public string? Address { get; set; }
        }
    }
}