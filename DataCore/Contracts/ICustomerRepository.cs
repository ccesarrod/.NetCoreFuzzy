using fuzzy.core.Entities;
using fuzzy.core.Models;
using System.Collections.Generic;

namespace fuzzy.core.DataCore.Contracts
{
   public interface ICustomerRepository:IRepository<Customer>
    {
        List<CartDetails> SyncShoppingCart(string userEmail, List<Cart> cartUpdates);
        List<CartDetails> GetShoopingCart(string userEmail);
      ///  void DeleteShoppingCart(string userEmail);
        //void AddOrder(string userEmail, Order order);
    }
}
