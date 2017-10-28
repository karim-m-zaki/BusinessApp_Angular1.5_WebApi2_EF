using BusinessApp_AsgaTech.Models.Models;
using BusinessApp_AsgaTech.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessApp_AsgaTech.WebAPI.Core
{
    public class UserQuery
    {
        public List<UserViewModel> GetAllUsers()
        {
            using (var db = new AsgaTechContext())
            {
                var userList = db.Users.Select(x => new UserViewModel
                {
                    UserName = x.UserName,
                    Email = x.Email,
                    Id = x.Id
                }).ToList();

                return userList;
            }
        }

        public UserEdit GetUserEditById(int id)
        {
            using (var db = new AsgaTechContext())
            {
                var output = db.Users.Where(x => x.Id == id).Select(z => new UserEdit
                {
                    UserName = z.UserName,
                    Email = z.Email,
                    Id = z.Id,
                }).SingleOrDefault();

                return output;
            }
        }

        public UserViewModel GetUserById(int id)
        {
            using (var db = new AsgaTechContext())
            {
                var output = db.Users.Where(x => x.Id == id).Select(z => new UserViewModel
                {
                    UserName = z.UserName,
                    Email = z.Email,
                    Id = z.Id,
                }).SingleOrDefault();

                return output;
            }
        }

        internal bool UserExist(int id)
        {
            using (var db = new AsgaTechContext())
            {
                return db.Users.Count(e => e.Id == id) > 0;
            }
        }

        internal User GetUserByEmail(string email)
        {
            using (var db = new AsgaTechContext())
            {
                var user = db.Users.Where(x => x.Email == email).SingleOrDefault();

                return user;
            }
        }

        internal List<UserRole> GetAllRolesByUserId(int id)
        {
            using (var db = new AsgaTechContext())
            {
                var userRoles = db.UserRole.Where(x => x.UserId == id).ToList();

                return userRoles;
            }
        }
    }
}