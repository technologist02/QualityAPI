using Quality2.Database;

namespace Quality2.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Function {  get; set; }
        public List<User> Users { get; set; }

    }
}
