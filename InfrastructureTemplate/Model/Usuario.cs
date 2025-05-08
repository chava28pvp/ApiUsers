using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfrastructureTemplate.Model
{
    public class Users
    {
        [Key]
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RoleId { get; set; }
        public Roles Roles { get; set; }
    }
    public class Roles
    {
        [Key]
        public int IdRole { get; set; }
        public string Role { get; set; }

        public ICollection<Users> Users { get; set; }
    }

    
   
}
