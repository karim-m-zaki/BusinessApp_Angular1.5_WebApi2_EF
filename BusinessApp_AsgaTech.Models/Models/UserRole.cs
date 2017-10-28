using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessApp_AsgaTech.Models.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        [Column("UserId", Order = 0)]
        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        [Column("RoleId", Order = 1)]
        [Required, ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}