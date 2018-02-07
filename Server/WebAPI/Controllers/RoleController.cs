using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.DTO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IRoleService _servRole;

        public RoleController(IMapper iMapper, IRoleService servRole)
        {
            _iMapper = iMapper;
            _servRole = servRole;
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _servRole.GetAll();
            return Ok(roles);
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int? id)
        {
            var role = await _servRole.GetById(id.Value);
            return Ok(role);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody]RoleDTO roleDTO)
        {
            int result = await _servRole.Create(roleDTO);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateRoleById([FromBody]RoleDTO roleDTO)
        {
            int result = await _servRole.Update(roleDTO);
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
        public async Task<IActionResult> DeleteRoleById(int? id)
        {
            int result = await _servRole.DeleteById(id.Value);
            return Ok(result);
        }
    }
}
