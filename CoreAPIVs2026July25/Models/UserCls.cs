namespace CoreAPIVs2026July25.Models
{
    public class UserCls
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Photo { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

    }
    public  class UserCreateDTO
    {
               public string? Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public IFormFile? Path { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

    }
    public class UserLoginDTO
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
