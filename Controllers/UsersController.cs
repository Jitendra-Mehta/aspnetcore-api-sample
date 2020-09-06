using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_api_sample.Models;
using aspnetcore_api_sample.Models.ViewModels;
using aspnetcore_api_sample.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_api_sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult users()
        {
            var data = _IUserServices.getUserList();
           
            return Ok(data);
        }
        [HttpPost]
        public ActionResult users([FromBody] User obj)
        {
            _IUserServices.AddNewUser(obj);
            return Ok(); 
        }
       
        [HttpPut]
        public ActionResult UpdateUser([FromBody] User obj)
        {
            _IUserServices.UpdateNewUser(obj);
            return Ok();
        }
        [HttpGet , Route("usersById/{id}")]        
        public ActionResult usersById(int id)
        {
            var data = _IUserServices.getUserById(id);
            return Ok(data);
        }
        [HttpPost, Route("authenticate")]
        public ActionResult authenticate([FromBody] userAuthenticate obj)
        {
            var data = _IUserServices.ValidateUser(obj);
            return Ok(data);
        }
        private IUserServices _IUserServices;       
        public UsersController(IUserServices IUserServices, IMapper mapper)
        { 
            _IUserServices = IUserServices;
        }
    }
}
