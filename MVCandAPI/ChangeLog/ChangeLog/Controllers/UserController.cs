using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ChangeLog.Model.User;
using ChangeLog.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChangeLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService )
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            var token = _userService.AuthenticateUser(loginModel);
            
            if(string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Username or password is incorrect" }); 
           
            return Ok(new { token = token });
        }
    }
}
