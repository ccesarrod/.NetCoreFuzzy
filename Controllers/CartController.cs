using fuzzy.core.DataCore.Contracts;
using fuzzy.core.Entities;
using fuzzy.core.Models;
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
        private readonly ICustomerRepository _customerRepository;

        public CartController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost]
        
        public ActionResult Save(Cart[] cartView)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var customer = GetAutenticatedCustomer();
                _customerRepository.SyncShoppingCart(customer.Email, cartView.ToList());

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
           
            return _customerRepository.Find(x => x.Email == user).FirstOrDefault();
        }
    }
}