using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model.User;

namespace Monitoring4M1Ev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<object>> GetAllUserDetails()
        {
            var newFormat = _userService.GetAllUserDetails().Select(u => new
            {
                u.UserDetailId,
                u.OperatorEmployeeId,
                u.Username,
                u.PasswordHash,
                u.FirstName,
                u.LastName,
                u.Role,
                u.IsActive,
                u.CreatedBy,
                u.CreatedDate,
                u.UpdatedDate,
                UserLines = u.UserLines.Select(ul => ul.Line).ToArray()
            });

            return Ok(newFormat);

        }

        [HttpGet("{id}")]
        public ActionResult<UserDetail> GetUserDetailById(int id)
        {
            return Ok(_userService.GetUserDetailById(id));
        }

        [HttpPost("addline/{id}")]
        public ActionResult AddNewLineForUser(int id, [FromBody] string[] Lines)
        {
            _userService.AddNewLineForUser(id, Lines);
            return Ok();
        }

        [HttpPost]
        public ActionResult AddUser([FromBody] UserDetailDto dto)
        {
            _userService.AddUser(dto, 1);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePassword(int id,[FromBody] string password)
        {
            _userService.UpdatePassword(id, password);
            return Ok();
        }

    }
}