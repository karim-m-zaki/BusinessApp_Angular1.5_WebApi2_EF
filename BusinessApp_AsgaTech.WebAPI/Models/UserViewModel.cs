using System.Collections.Generic;

namespace BusinessApp_AsgaTech.WebAPI.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public ICollection<RoleViewModel> Roles { get; set; }
    }
}