using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ChangeLog.Model.User;
using ChangeLog.Service.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChangeLog.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService/*, SignInManager<AppUser> signInManager*/)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        public IActionResult GoogleLogin(string returnUrl)
        {
            return new ChallengeResult(
            GoogleDefaults.AuthenticationScheme,
            new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(GoogleResponse), new { returnUrl })
            });
        }

        [AllowAnonymous]
        public async Task GoogleResponse()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync("External");

            if (!authenticateResult.Succeeded)
                HttpContext.Response.Redirect("http://localhost:4200/login?error=Email on login.");


            string email = authenticateResult.Principal.FindFirst(ClaimTypes.Email).Value;
            var token = _userService.AuthenticateUser(email);

            if (!string.IsNullOrEmpty(token))
            {
                HttpContext.Response.Redirect("http://localhost:4200/login?token=" + token);
            }
            else
            {
                HttpContext.Response.Redirect("http://localhost:4200/login?error=Email id not found");
            }
        }
    }
}
