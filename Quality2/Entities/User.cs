namespace Quality2.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }
        //public byte[] PasswordSalt { get; set; }
        public string Role { get; set; } = "Guest";
        public DateTime Created { get; set; }
    }
}
