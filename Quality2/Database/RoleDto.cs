using Microsoft.EntityFrameworkCore;
using Quality2.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality2.Database
{
    [Table("UserRoles")]
    [PrimaryKey(nameof(RoleId))]
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string Function { get; set; }
        public List<UserDto>? Users { get; set; }
    }
}
