﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlannerProject.Helpers;
using PlannerProject.Models;
using PlannerProject.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PlannerProject.Controllers
{
    public class LoginController : Controller
    {
        IAuthService _authService;
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Index()
        {
            return View("Login");
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                if (_authService.ValidateUser(user, out string token))
                {
                    Response.Cookies.Append(Constants.TokenKey, token);
                    return Redirect(Url.Action("Index", "Home"));
                }
            }
            return View("Login");
        }
    }
}