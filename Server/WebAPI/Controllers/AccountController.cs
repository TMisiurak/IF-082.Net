using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.DTO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserDTO userDTO)
        {
            if (userDTO == null || string.IsNullOrEmpty(userDTO.Password))
            {
                return BadRequest();
            }
            int result = await _userService.Create(userDTO);
            if (result > 0)
            {
                //return CreatedAtRoute("GetDiagnosis", new { result = result });
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
