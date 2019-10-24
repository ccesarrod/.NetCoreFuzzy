using fuzzy.core.DataCore.Contracts;
using fuzzy.core.Entities;
using fuzzy.core.Models;
using fuzzy.core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace fuzzy_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CartController(ICustomerService customerRepository)
        {
            _customerService = customerRepository;
        }

        [HttpPost]
        [Authorize(JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Save(Cart[] cartView)
        {
            if (HttpContext.User.Identities.Any())
            {
                var customer = GetAutenticatedCustomer();
                _customerService.SyncShoppingCart(customer.Email, cartView.ToList());

                return Ok(new {
                    cart = cartView
                });
            }

            return NotFound();
        }

        private Customer GetAutenticatedCustomer()
        {

            return User.Identity.IsAuthenticated ? GetCustomerByEmail() : new Customer();
        }

        private Customer GetCustomerByEmail()
        {
            var user = HttpContext.User.Identity.Name;

            return _customerService.getByEmail(user);
        }
    }
}