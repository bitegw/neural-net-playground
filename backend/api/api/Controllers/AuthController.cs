﻿using api.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Services;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _auth;
        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterRequest user)
        {
            
            return Ok(_auth.Register(user));
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(AuthRequest user)
        {
            
            return Ok(_auth.Login(user));
        }


    }
}
