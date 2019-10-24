using fuzzy.core.DataCore.Contracts;
using fuzzy.core.DataCore.Repository;
using fuzzy.core.Entities;
using fuzzy.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fuzzy.core.Services
{
    public interface ICustomerService
    {
        Customer Authenticate(string email, string password);
        Customer GetById(string id);

       Customer  AddUser(Customer user);

        Customer getByEmail(string email);

        List<CartDetails> SyncShoppingCart(string userEmail, List<Cart> cartUpdates);
        List<CartDetails> GetShoopingCart(string userEmail);
    }
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private  ICartDetailsRepository _cartDetailsRepository;

        public CustomerService(ICustomerRepository context, IProductRepository product, ICartDetailsRepository cartDetailsRepository)
        {
            _customerRepository = context;
            this._productRepository = product;
            _cartDetailsRepository = cartDetailsRepository;
        }
        public Customer Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = _customerRepository.GetAll().SingleOrDefault(x => x.Email == email);

         
            if (user == null)
                return null;

         
            return user;
        }

        public Customer GetById(string id)        {
            
                return _customerRepository.Find(x=>x.CustomerID == id).SingleOrDefault();           
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

       

        public Customer AddUser(Customer user)
        {
            _customerRepository.Add(user);

           return  _customerRepository.Find(newuser => newuser.Email == user.Email).Single();
        }

        public Customer getByEmail(string email)
        {
            var y = _customerRepository.Find(x => x.Email != null).FirstOrDefault(t=>t.Email.Trim() == email.Trim());

            return y;
        }

        public List<CartDetails> SyncShoppingCart(string userEmail, List<Cart> cartUpdates)
        {


            var customer = getByEmail(userEmail);


            if (customer == null || !cartUpdates.Any()) return customer.Cart;

            if (customer != null && customer.Cart == null)
            {
                customer.Cart = cartUpdates.Select(
                    x => new CartDetails { Price = x.Price, Quantity = x.Quantity, ProductId = x.Id, Product = GetProductById(x.Id) })
                    .ToList();
                _customerRepository.Update(customer);
                _customerRepository.Save();

            }

            else
            {
                if (customer.Cart == null) {
                    customer.Cart = new List<CartDetails>();
                }

               var cartList = _cartDetailsRepository.Find(x=>x.CustomerID == customer.CustomerID).ToList();
                cartList.ForEach(m => _cartDetailsRepository.Delete(m));
                _cartDetailsRepository.Save();
                customer.Cart.RemoveAll(x => x.CustomerID != null);

                foreach (var item in cartUpdates)
                {
                    var cartItem = customer.Cart.SingleOrDefault(x => x.ProductId == item.Id);
                    if (cartItem == null)
                        customer.Cart.Add(new CartDetails
                        {
                            Price = item.Price,
                            Quantity = item.Quantity,
                            ProductId = item.Id,
                            Product = GetProductById(item.Id)
                        });

                    else

                        if (cartItem.Quantity != item.Quantity) cartItem.Quantity += item.Quantity;
                }
            }


            _customerRepository.Update(customer);
            _customerRepository.Save();
            return customer.Cart;
        }

        private Product GetProductById(int id)
        {
            return _productRepository.Find(x => x.ProductID == id).SingleOrDefault();
        }

        public List<CartDetails> GetShoopingCart(string userEmail)
        {

            var customer = getByEmail(userEmail);
            var cart = _cartDetailsRepository.Find(item => item.CustomerID == customer.CustomerID).ToList();
            customer.Cart = cart.Any() ? cart : new List<CartDetails>();
            return cart;
        }
    }
}
