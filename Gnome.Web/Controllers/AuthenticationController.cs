﻿using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services;
using Gnome.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gnome.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService userService;
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IUserService userService, IAuthenticationService authenticationService)
        {
            this.userService = userService;
            this.authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Redirect("/Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            var user = userService.Verify(loginUser);
            if (user != null)
            {
                await authenticationService.LogIn(user, HttpContext);
                return Redirect("/Home");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            authenticationService.LogOut(HttpContext);
            return Redirect("/Home");
        }
    }
}
