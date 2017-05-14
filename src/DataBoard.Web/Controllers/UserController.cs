using System.Collections.Generic;
using DataBoard.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataBoard.Web.Controllers
{
    [Route("/api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public JsonResult GetUsers()
        {
            return Json(_userService.GetAll());
        }
    }
}