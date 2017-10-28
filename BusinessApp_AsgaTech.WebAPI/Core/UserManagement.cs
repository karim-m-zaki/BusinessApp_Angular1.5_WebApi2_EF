using BusinessApp_AsgaTech.Models.Models;
using BusinessApp_AsgaTech.WebAPI.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;

namespace BusinessApp_AsgaTech.WebAPI.Core
{
    public class UserManagement
    {
        private readonly UserQuery _userQ;

        public UserManagement(UserQuery userQ)
        {
            _userQ = userQ;
        }

        public User AddUser(UserEdit user)
        {
            user.Password = Crypto.HashPassword(user.Password);

            //Mapping
            var userEntity = new User();
            userEntity.UserName = user.UserName;
            userEntity.Password = user.Password;
            userEntity.Email = user.Email;

            using (var db = new AsgaTechContext())
            {
                db.Users.Add(userEntity);

                var result = db.SaveChanges();
                var newUser = _userQ.GetUserByEmail(userEntity.Email);

                return newUser;
            }
        }

        //Adding user roles at UserRole Table
        public int AddUserRoles(int userId, int roleId)
        {
            var userRole = new UserRole();
            userRole.UserId = userId;
            userRole.RoleId = roleId;

            using (var db = new AsgaTechContext())
            {
                db.UserRole.Add(userRole);

                var result = db.SaveChanges();

                return result;
            }
        }

        public User UpdateUser(UserEdit user)
        {
            using (var db = new AsgaTechContext())
            {
                var userEntity = db.Users.Where(x => x.Id == user.Id).SingleOrDefault();
                userEntity.Id = user.Id;
                userEntity.UserName = user.UserName;
                userEntity.Email = user.Email;

                db.Entry(userEntity).State = EntityState.Modified;

                db.SaveChanges();

                var updatedUser = db.Users.Where(x => x.Id == user.Id).SingleOrDefault();

                return updatedUser;
            }
        }

        public int DeleteUser(UserViewModel user)
        {
            //Get all Roles of this user from UserRole table
            var userRoles = _userQ.GetAllRolesByUserId(user.Id);
            using (var db = new AsgaTechContext())
            {
                //Delete all Roles of the user we want to delete
                foreach (var userRole in userRoles)
                {
                    db.UserRole.Attach(userRole);
                    db.UserRole.Remove(userRole);
                    db.SaveChanges();
                }

                //Then Delete the user itself from User table

                var userEntity = db.Users.Where(x => x.Id == user.Id).SingleOrDefault();

                db.Users.Remove(userEntity);

                var result = db.SaveChanges();

                return result;
            }
        }
    }
}