using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.DTO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly IMapper _iMapper;

        private readonly IService<RoomDTO> _servRoom;

        public RoomController(IMapper iMapper, IService<RoomDTO> servRoom)
        {
            _iMapper = iMapper;
            _servRoom = servRoom;
        }

        [HttpPost("create_room")]
        public async Task<IActionResult> CreateRoom([FromBody]RoomDTO roomDTO)
        {
            int result = await _servRoom.Create(roomDTO);
            return Ok(result);
        }

        [HttpDelete("delete_room/{id}")]
        public async Task<IActionResult> DeleteRoomById(int? id)
        {

            int result = await _servRoom.DeleteById(id.Value);
            return Ok(result);

        }
        
        [HttpGet("/all_rooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _servRoom.GetAll();
            return Ok(rooms);
        }

        [HttpGet("/room/{id}")]
        public async Task<IActionResult> GetRoomById(int? id)
        {
            var room = await _servRoom.GetById(id.Value);
            return Ok(room);
        }
    }
}
