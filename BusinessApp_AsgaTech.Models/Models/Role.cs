using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessApp_AsgaTech.Models.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        
        public string RoleName { get; set; }

        public bool Selected { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

    }
}