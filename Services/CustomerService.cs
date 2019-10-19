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
        private IRepository<Customer> _customerRepository;
        private readonly IProductRepository _productRepository;

        public CustomerService(IRepository<Customer> context, IProductRepository product)
        {
            _customerRepository = context;
            this._productRepository = product;
        }
        public Customer Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = _customerRepository.GetAll().SingleOrDefault(x => x.Email == email);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct

            
         //   if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
              //  return null;

            // authentication successful
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

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
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


           // var xxx = customer.Cart.Select(x => !cartUpdates.Exists(y => y.Id == x.ProductId)).ToList();
            //customer.Cart.RemoveAll(x => !cartUpdates.Exists(y => y.Id == x.ProductId));

            _customerRepository.Update(customer);
            return customer.Cart;
        }

        private Product GetProductById(int id)
        {
            return _productRepository.Find(x => x.ProductID == id).SingleOrDefault();
        }

        public List<CartDetails> GetShoopingCart(string userEmail)
        {

            var customer = getByEmail(userEmail);
            return customer != null ? customer.Cart : new List<CartDetails>();
        }
    }
}
