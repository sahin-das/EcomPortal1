using EcomPortal.Models.Dtos.User;
using EcomPortal.Services;
using System.Threading.Tasks;
using System;
using System.Web.Http;
using System.Data.Entity.Validation;

namespace EcomPortal.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllUsers()
        {
            var Users = await _userService.GetAllAsync();
            return Ok(Users);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetUserById(Guid id)
        {
            var User = await _userService.GetByIdAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            return Ok(User);
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateUser([FromBody] AddUserDto request)
        {
            try
            {
                var user = await _userService.CreateAsync(request);
                return Ok(user);
            }
            catch (DbEntityValidationException ex)
            {
                return BadRequest("Validation failed: " + ex.EntityValidationErrors);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateUser(Guid id, [FromBody] UpdateUserDto request)
        {
            var User = await _userService.UpdateAsync(id, request);
            return Ok(User);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return Ok("Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
