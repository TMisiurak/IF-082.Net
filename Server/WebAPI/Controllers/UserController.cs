using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapper iMapper)
        {
            _userService = userService;
            _iMapper = iMapper;
        }
        
        [Authorize(Roles = "admin")]
        [HttpGet("get_all")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAll();
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }
        
        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUserById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var user = await _userService.GetById(id.Value);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserById([FromBody]UserDTO userDTO)
        {
            if (userDTO == null || string.IsNullOrEmpty(userDTO.Password))
            {
                return BadRequest();
            }
            userDTO.Password = HashService.HashPassword(userDTO.Password);
            int result = await _userService.Update(userDTO);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUserById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            int result = await _userService.DeleteById(id.Value);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        protected override void Dispose(bool disposing)
        {
            _userService.Dispose();
            base.Dispose(disposing);
        }
    }
}
