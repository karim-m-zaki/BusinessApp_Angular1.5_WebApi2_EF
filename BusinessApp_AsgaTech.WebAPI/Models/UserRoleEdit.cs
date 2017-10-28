using BusinessApp_AsgaTech.Models.Models;
using System.Collections.Generic;

namespace BusinessApp_AsgaTech.WebAPI.Models
{
    public class UserRoleEdit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Role> Roles { get; set; }
    }
}