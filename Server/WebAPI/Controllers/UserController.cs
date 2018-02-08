using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            IList<UserDTO> users = await _userService.GetAll();
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            UserDTO user = await _userService.GetById(id.Value);
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
        [HttpPut]
        public async Task<IActionResult> UpdateUserById([FromBody]UserDTO userDTO)
        {
            if (userDTO == null || string.IsNullOrEmpty(userDTO.Password))
            {
                return BadRequest();
            }
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
        [HttpDelete("{id}")]
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
    }
}
