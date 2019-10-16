using System.Collections.Generic;
using System.Linq;
using fuzzy.core.DataCore.Contracts;
using fuzzy.core.Entities;
using fuzzy.core.Models;

namespace fuzzy.core.DataCore.Repository
{
    public class CustomerRepository: Repository<Customer> ,ICustomerRepository
    {
        private readonly IProductRepository _productRepository;

        public CustomerRepository(CustomerOrderContext context, IProductRepository product): base (context)
        {
            
           _productRepository = product;
          
        }

        public List<CartDetails> SyncShoppingCart(string userEmail, List<Cart> cartUpdates)
        {


            var customer = Find(x => x.Email == userEmail).FirstOrDefault();

           
            if (customer != null && cartUpdates.Any()) return customer.Cart;

            if (customer != null && customer.Cart.Count == 0)
            {
                customer.Cart = cartUpdates.Select(
                    x => new CartDetails { Price = x.Price, Quantity = x.Quantity, ProductId = x.Id, Product = GetProductById(x.Id) })
                    .ToList();
               Update(customer);
              Save();            

            }

            else
            {
                var customerCart = customer != null ? customer.Cart : new List<CartDetails>();
                foreach (var item in cartUpdates)
                {
                    var cartItem = customerCart.SingleOrDefault(x => x.ProductId == item.Id);
                    if (cartItem == null)
                        customerCart.Add(new CartDetails
                        {
                            Price = item.Price,
                            Quantity = item.Quantity,
                            ProductId = item.Id,
                            Product = GetProductById(item.Id)
                        });

                    else

                        if (cartItem.Quantity != item.Quantity) cartItem.Quantity = item.Quantity;
                }
            }


            var xxx = customer.Cart.Select(x => !cartUpdates.Exists(y => y.Id == x.ProductId)).ToList();
            customer.Cart.RemoveAll(x => !cartUpdates.Exists(y => y.Id == x.ProductId));

            Update(customer);
            return customer.Cart;
        }

        private Product GetProductById(int id)
        {
            return _productRepository.Find(x => x.ProductID == id).SingleOrDefault();
        }

        public List<CartDetails> GetShoopingCart(string userEmail)
        {
           
            var customer = Find(x => x.Email == userEmail).SingleOrDefault();
            return customer != null ? customer.Cart : new List<CartDetails>();
        }
    }

   
}
