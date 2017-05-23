using System.Collections.Generic;
using DataBoard.Infrastructure.Commands.Users;
using DataBoard.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataBoard.Web.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Get()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            var user = _userService.Get(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateUser request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            _userService.Register(request.Email, request.Password);

            return Created($"/users/{request.Email}", request);
        }
    }
}