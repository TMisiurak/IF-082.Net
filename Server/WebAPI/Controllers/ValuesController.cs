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
        private readonly IService<RoomDTO> _servRoom;

        public ValuesController(IUserService serv, IMapper iMapper, IService<RoleDTO> servRole/*, IService<ClinicDTO> servClinic*/, 
            IService<RoomDTO> servRoom)
        {
            _serv = serv;
            _iMapper = iMapper;
            _servRole = servRole;
            //_servClinic = servClinic;
            _servRoom = servRoom;
        }

        // GET api/users
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _serv.GetAll();
            return Ok(users);
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

        // GET api/values/5
        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int? id)
        {
            var user = await _serv.GetById(id.Value);
            return Ok(user);
        }

        [Authorize(Roles = "admin, doctor, accountant")]
        [HttpGet("/get_all_rooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _servRoom.GetAll();
            return Ok(rooms);
        }

        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("/room/{id}")]
        public async Task<IActionResult> GetRoomById(int? id)
        {
            var room = await _servRoom.GetById(id.Value);
            return Ok(room);
        }

        protected override void Dispose(bool disposing)
        {
            _serv.Dispose();
            base.Dispose(disposing);
        }
    }
}
