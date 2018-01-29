using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public ValuesController(IUserService serv, IMapper iMapper)
        {
            _serv = serv;
            _iMapper = iMapper;
        }

        // GET api/values
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _serv.GetAll();
            return Ok(users);
        }

        // GET api/values/5
        [Authorize(Roles = "admin, patient, doctor, accountant")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int? id)
        {
            var user = await _serv.GetById(id.Value);
            return Ok(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int? id)
        {
            int result = await _serv.DeleteById(id.Value);
            return Ok(result);

        }

        protected override void Dispose(bool disposing)
        {
            _serv.Dispose();
            base.Dispose(disposing);
        }
    }
}
