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
        [Authorize(Roles = "admin")]
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            var users = _serv.GetUsers();
            return Json(users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var user = _serv.GetUserById(id);
            return Json(user);
        }

        //[HttpGet("{email}")]
        //public JsonResult Get(string email)
        //{
        //    var user = _serv.GetUserByEmail(email);
        //    return Json(user);
        //}
    }
}
