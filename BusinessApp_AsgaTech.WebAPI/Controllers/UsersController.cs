using BusinessApp_AsgaTech.WebAPI.Core;
using BusinessApp_AsgaTech.WebAPI.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BusinessApp_AsgaTech.WebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:54174", "*", "*")]
    public class UsersController : ApiController
    {
        private readonly UserQuery _userQ;
        private readonly UserManagement _userM;

        public UsersController(UserQuery userQ, UserManagement userM)
        {
            _userQ = userQ;
            _userM = userM;
        }

        // GET: api/Users
        [HttpGet]
        [Route("api/users/getallusers")]
        public List<UserViewModel> GetUsers()
        {
            var userList = _userQ.GetAllUsers();

            return userList;
        }

        // GET: api/Users/5
        [HttpGet]
        [Route("api/users/getuser/{id}")]
        public IHttpActionResult GetUser(int id)
        {
            var user = _userQ.GetUserEditById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPost]
        [Route("api/users/editUser")]
        public IHttpActionResult PutUser(UserEdit user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedUser = _userM.UpdateUser(user);
                if (updatedUser == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(updatedUser);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Users
        [HttpPost]
        [Route("api/users/createuser")]
        public IHttpActionResult PostUser(UserEdit user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var u = _userQ.GetUserByEmail(user.Email);
            if (u != null)
            {
                return BadRequest("Email already exit");
            }

            var newUser = _userM.AddUser(user);

            if (newUser.Id < 1)
            {
                return InternalServerError();
            }

            //return CreatedAtRoute("DefaultApi", new { id = newUser.Id }, newUser);
            return Ok(newUser);
        }

        // POST: api/Users
        [HttpPost]
        [Route("api/users/adduserroles")]
        public IHttpActionResult AddUserRoles(UserRoleEdit userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var role in userRole.Roles)
            {
                _userM.AddUserRoles(userRole.UserId, role.Id);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/users/delete/{id}")]
        public IHttpActionResult DeleteUser(int id)
        {
            var user = _userQ.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            var res = _userM.DeleteUser(user);
            if (res < 1)
            {
                return InternalServerError();
            }
            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _userQ.UserExist(id);
        }
    }
}