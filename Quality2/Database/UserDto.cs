﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quality2.Database
{
    [Index(nameof(Login), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    [Table("UsersInfo")]
    public class UserDto
    {
        public int ID { get; set; }
        [Required]
        public string Login { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; }

        public string PasswordHash { get; set; }
        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }
        public List<RoleDto> Roles { get; set; }
        public DateTime Created { get; set; }
    }
}