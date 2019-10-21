using fuzzy.core.DataCore.Contracts;
using fuzzy.core.Entities;
using fuzzy.core.Models;
using fuzzy.core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        private readonly ICustomerRepository _customerRepository;
        private static object _lock = new object();

        public AccountController(ICustomerService customerService, IOptions<AppSettings> appSettings, 
            SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ICustomerRepository customerRepository)
        {
            _customerService = customerService;
            _appSettings = appSettings.Value;
            _signInManager = signInManager;
            _userManager = userManager;
            _customerRepository = customerRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]Login login)
        {
            var theUser = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, lockoutOnFailure: false);


            if (theUser.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(login.UserName);
                //var currentCart = _customerRepository.SyncShoppingCart(model.Email, cartFromCookie);
                var currentCart = _customerService.GetShoopingCart(user.Email);
                var list = currentCart.Select(i => new Cart() { Id = i.Id, Quantity=i.Quantity,Price=i.Price,ProductId = i.ProductId});
                string tokenString = GetToken(user.Email);
                return Ok(new
                {
                    email = user.Email,
                    userName = user.UserName,
                    cart = list,
                     Token = tokenString
                });
            }

            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Login login)
        {
            var user = _customerService.Authenticate(login.UserName, login.Password);

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


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel register, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            Customer customer = null;
            
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = register.UserName, Email = register.Email };
                var result = await _userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    try
                    {
                        var id = GetShortID();
                        customer = _customerService.AddUser(new Customer { Email = register.Email, ContactName = register.FirstName + "  " + register.LastName, CompanyName= "Company name", CustomerID=id });
                    }
                    catch(Exception ex)
                    {
                        return BadRequest(ex);
                    }
                    
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                  
                }
            }

            return Ok(new
            {
                email = customer.Email
            });

        }

        private string GetToken(string email)
        {
            String tokenString="";
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, email)
                    }),
                    //  Audience = "http://localhost/4200",
                    // EncryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.None),
                    Issuer = "http://localhost:52070",
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                //  var token= new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
                tokenString = tokenHandler.WriteToken(token);

                return tokenString;
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }

            return tokenString;
        }

      

        /// <summary>
        /// Return a string of random hexadecimal values which is 6 characters long and relatively unique.
        /// </summary>
        /// <returns></returns>
        /// <remarks>In testing, result was unique for at least 10,000,000 values obtained in a loop.</remarks>
        public static string GetShortID()
        {
            lock (_lock)
            {
                var crypto = new System.Security.Cryptography.RNGCryptoServiceProvider();
                var bytes = new byte[4];
                crypto.GetBytes(bytes,0,4); // get an array of random bytes.      
                return BitConverter.ToString(bytes,0,4).Replace("-", string.Empty).Substring(0,5); // convert array to hex values.
            }
        }
    }
}