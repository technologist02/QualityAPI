namespace Quality2.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; }
        public List<Role> Roles { get; set; }
        public DateTime Created { get; set; }
    }
}
