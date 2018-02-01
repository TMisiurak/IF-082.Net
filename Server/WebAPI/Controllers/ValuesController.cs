using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly IUserService _serv;
        private readonly IService<RoleDTO> _servRole;
        //private readonly IService<ClinicDTO> _servClinic;

        public ValuesController(IUserService serv, IMapper iMapper, IService<RoleDTO> servRole/*, IService<ClinicDTO> servClinic*/)
        {
            _serv = serv;
            _iMapper = iMapper;
            _servRole = servRole;
            //_servClinic = servClinic;
        }

        // GET api/roles
        [Authorize(Roles = "admin")]
        [HttpGet("/all_roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _servRole.GetAll();
            return Ok(roles);
        }

        //// GET api/roles
        //[Authorize(Roles = "admin")]
        //[HttpGet("/all_clinics")]
        //public async Task<IActionResult> GetClinics()
        //{
        //    var clinics = await _servClinic.GetAll();
        //    return Ok(clinics);
        //}
        
        protected override void Dispose(bool disposing)
        {
            _serv.Dispose();
            base.Dispose(disposing);
        }
    }
}
