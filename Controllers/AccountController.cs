﻿using fuzzy.core.Entities;
using fuzzy.core.Models;
using fuzzy.core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace fuzzy_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly AppSettings _appSettings;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(ICustomerService customerService, IOptions<AppSettings> appSettings, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager )
        {
            _customerService = customerService;
            _appSettings = appSettings.Value;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]Login login)
        {
               var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, lockoutOnFailure: false);
            //var user1 = new ApplicationUser { UserName = login.Email, Email = login.Email};
            //var result = await _userManager.CreateAsync(user1, login.Password);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                //string tokenString = GetToken(user.Email);
                return Ok(new
                {
                    email = user.Email
                   
                });
            }

            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Login login)
        {
            var user = _customerService.Authenticate(login.Email, login.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            string tokenString = GetToken(user.Email);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                
                email = user.Email,
                Token = tokenString
            });
        }

        private string GetToken(string email )
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}