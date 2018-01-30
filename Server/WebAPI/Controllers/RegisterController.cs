using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserDTO userDTO)
        {
            userDTO.Password = HashService.HashPassword(userDTO.Password);
            int result = await _userService.CreateAsync(userDTO);
            return Ok(result);
        }

        // UPDATE api/values/5
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserById([FromBody]UserDTO userDTO)
        {
            userDTO.Password = HashService.HashPassword(userDTO.Password);
            int result = await _userService.Update(userDTO);
            return Ok(result);
        }

        // DELETE api/values/5
        [HttpDelete("delete_user/{id}")]
        public async Task<IActionResult> DeleteUserById(int? id)
        {
            int result = await _userService.DeleteByIdAsync(id.Value);
            return Ok(result);
        }
    }
}
