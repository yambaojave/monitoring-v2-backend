using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model.User;

namespace Monitoring4M1Ev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginUser user)
        {
            var userCred = _userService.LoginUser(user);

            if (userCred == null)
            {
                return BadRequest(new { error = "User not found!" });
            }

            if (!_userService.CheckPassword(user))
            {
                return BadRequest(new { error = "Wrong Password!" });
            }

            string token = CreateToken(userCred);

            return Ok(new { token });
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
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
        [Authorize(Roles = "ADMIN")]
        public ActionResult<UserDetail> GetUserDetailById(int id)
        {
            return Ok(_userService.GetUserDetailById(id));
        }

        [HttpPost("addline/{id}")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult AddNewLineForUser(int id, [FromBody] string[] Lines)
        {
            _userService.AddNewLineForUser(id, Lines);
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
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

        [HttpGet("lines")]
        public ActionResult GetAvailLines()
        {
            return Ok(_userService.GetAvailLines());
        }

        [HttpPost("lines")]
        public ActionResult PostAvailLines([FromBody] Lines line)
        {
            _userService.AddNewLine(line);
            return Ok();
        }




        private string CreateToken(UserDetail user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.UserDetailId.ToString()),
                new Claim("username", user.Username),
                new Claim("name", $"{user.LastName}, {user.FirstName}"),
                new Claim("Roles", user.Role),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("Lines", string.Join(", ", user.UserLines.Select(e => e.Line).ToArray())),
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);


            return jwt;
        }

    }
}