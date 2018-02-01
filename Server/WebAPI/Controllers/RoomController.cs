using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Authorize(Roles = "admin, doctor, accountant")]
        [HttpGet("/all_rooms")]
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
    }
}
