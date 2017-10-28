using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessApp_AsgaTech.Models.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = ("User Name max length is 50."))]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}